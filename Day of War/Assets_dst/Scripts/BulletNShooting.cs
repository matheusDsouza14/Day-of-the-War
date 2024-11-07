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
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        canshoot = true;
    }
    private void Update()
    {
        if (GameManager.ammo <= 0 && !isReloading)
        {
            canshoot = false;
            StartCoroutine(Reload());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.playerhealth -= 1;
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.enemiesleft -= 1;
        }
        if (other.CompareTag("Boss"))
        {
            if (GameManager.bossBattleToggle == true && this.CompareTag("Player"))
            {
                GameManager.bossHealth -= 2;
            }
        }
    }
    public void Shooting()
    {
        if (canshoot)
        {
            float bulletSpeed = 100f;
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            GameManager.ammo -= 1;
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