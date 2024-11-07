using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health;
    [SerializeField] Transform player;
    [SerializeField] GameManager gameManager;
    [SerializeField] BulletNShooting bulletNshooting;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        bulletNshooting = GetComponent<BulletNShooting>();
        player = GameObject.Find("Plane").GetComponent<Transform>();
        StartCoroutine(shootingenemy());
    }
    void Update()
    {
        //transform.Translate();
        transform.LookAt(player);
    }
    private IEnumerator shootingenemy()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 2; i++)
        {
            bulletNshooting.Shooting();
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
