using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirst : MonoBehaviour
{
    public int health;
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] GameManager gameManager;
    [SerializeField] BulletNShooting bulletNshooting;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        bulletNshooting = GetComponent<BulletNShooting>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(4f, 6f);
        StartCoroutine(shootingenemy());
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
