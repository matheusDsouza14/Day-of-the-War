using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColision : MonoBehaviour
{
    private GameManager GameManager;
    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "BulletEnemy(Clone)")
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.playerhealth -= 10;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.name == "BulletPlayer(Clone)")
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                GameManager.enemiesleft -= 1;
            }
        }
    }
}
