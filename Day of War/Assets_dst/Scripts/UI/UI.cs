using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Slider playerhealthSlider;
    [SerializeField] private Slider bossHealthSlider;
    [SerializeField] private TMP_Text bossnametext;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private GameObject LostPanel;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerhealthSlider.maxValue = gameManager.playermaxHealth;
        bossHealthSlider.maxValue = gameManager.bossHealth;
        bossHealthSlider.gameObject.SetActive(false);
        bossnametext.gameObject.SetActive(false);
    }
    void Update()
    {
        bossHealthSlider.value = gameManager.bossHealth;
        playerhealthSlider.value = gameManager.playerhealth;
        ammoText.text = "AMMO: " + gameManager.ammo;
        if (gameManager.bossBattleToggle == true)
        {
            bossHealthSlider.gameObject.SetActive(false);
            bossHealthSlider.gameObject.SetActive(true);
            bossnametext.gameObject.SetActive(true);
        }
        if (gameManager.playerhealth <= 0)
        {
            ammoText.gameObject.SetActive(false);
            playerhealthSlider.gameObject.SetActive(false);
            bossHealthSlider.gameObject.SetActive(false);
            bossnametext.gameObject.SetActive (false);
            LostPanel.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            bossnametext.text = "Arthur Morgan";
        }
        else
        {
            bossnametext.text = "Samus";
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
