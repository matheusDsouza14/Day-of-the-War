using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health;
    [SerializeField] Transform player;
    [SerializeField] GameManager gameManager;
    [SerializeField] float topLeftCorne;
    [SerializeField] float topRightCorne;
    void Update()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //transform.Translate();
    }

}
