using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour
{
    [Header("Rules")]
    public float playerhealth;
    public float playermaxHealth;
    public float ammo;
    public float maxAmmo;
    public float bossmaxHealth;
    public float bossHealth;
    public bool bossBattleToggle;
    public int enemiesleft;
    [Header("CameraAnimation")]
    [SerializeField]private GameObject[] cameragameobject = new GameObject[2];
    [Header("GameObjects")]
    [SerializeField]private GameObject enemyprefab;
    void Start()
    {
        cameragameobject[0] = Camera.main.gameObject;
        cameragameobject[0].SetActive(true);
        cameragameobject[1].SetActive(false);
        Time.timeScale = 1;
        playermaxHealth = 100;
        playerhealth = playermaxHealth;
        maxAmmo = 10;
        ammo = maxAmmo;
        bossmaxHealth = 70;
        bossHealth = bossmaxHealth;
        enemiesleft = 6;
        InvokeRepeating("spawnenemy", 3f, 3f);
    }
    void Update()
    {
        //scrolltexture();
        if(bossBattleToggle==true)
        {
            cameragameobject[0].SetActive(false);
            cameragameobject[1].SetActive(true);
        }
        if(bossHealth <= 0 || enemiesleft <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void scrolltexture()
    {
        float scrollspeedx = 0f;
        float scrollspeedy = -1f;
        MeshRenderer meshRenderer = GameObject.Find("Floor").GetComponent<MeshRenderer>();
        meshRenderer.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup*scrollspeedx, Time.realtimeSinceStartup * scrollspeedy);
    }
    public void spawnenemy()
    {
        //Screen height and width to world space
        float distanceToEnemy = enemyprefab. transform.position.z - enemyprefab.transform.position.z;
        Instantiate(enemyprefab, new Vector3(66f, 54.7f, Random.Range(-25.7f, 31.3f)),Quaternion.identity);
    }
}
