using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletNShooting : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    [SerializeField] Transform[] normalBulletSpawn = new Transform[2];
    [SerializeField] Transform MissileSpawn;
    [SerializeField] GameObject bulletPrefab;
    public bool canshoot;
    private bool isReloading = false;
    private void Start()
    {
        normalBulletSpawn[1] = this.GetComponentInChildren<Transform>();
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (this.CompareTag("Player"))
        {
            for (int i = 0; i < normalBulletSpawn.Length; i++) {
                normalBulletSpawn[i] = this.gameObject.transform.GetChild(i);
            }
            MissileSpawn = this.transform.GetChild(2);
        }
        if (this.CompareTag("Enemy"))
        {
            normalBulletSpawn[0] = this.GetComponentInChildren<Transform>();
            normalBulletSpawn[1] = this.GetComponentInChildren<Transform>();
        }
        canshoot = true;
    }
    private void Update()
    {
        if (this.gameObject.name == "Plane")
        {
            if (GameManager.ammo <= 0 && !isReloading)
            {
                canshoot = false;
                StartCoroutine(Reload());
            }
        }
    }
    public void Shooting()
    {
        if (canshoot)
        {
            int random = Random.Range(0, normalBulletSpawn.Length);
            float bulletSpeed = 200f;
            var bullet = Instantiate(bulletPrefab, normalBulletSpawn[random].position, normalBulletSpawn[1].rotation);
            bullet.GetComponent<Rigidbody>().velocity = normalBulletSpawn[1].forward * bulletSpeed;
            if(this.gameObject.name == "Plane")
            {
                GameManager.ammo -= 1;
            }
            Destroy(bullet, 5f);
        }
    }
    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        while (GameManager.ammo < GameManager.maxAmmo)
        {
            GameManager.ammo++;
            yield return new WaitForSeconds(0.5f);
        }
        isReloading = false;
        canshoot = true;
    }
    
}