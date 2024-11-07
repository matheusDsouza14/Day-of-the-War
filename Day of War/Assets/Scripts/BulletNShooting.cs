using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletNShooting : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject bulletPrefab;
    public bool canshoot;
    private bool isReloading = false;
    private void Start()
    {
        bulletSpawn = this.GetComponentInChildren<Transform>();
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (this.CompareTag("Player"))
        {
            bulletSpawn = this.GetComponentInChildren<Transform>();
        }
        if (this.CompareTag("Enemy"))
        {
            bulletSpawn = this.GetComponentInChildren<Transform>();
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
            float bulletSpeed = 200f;
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
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