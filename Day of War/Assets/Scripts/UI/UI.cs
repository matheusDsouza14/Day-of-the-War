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
        bossHealthSlider.maxValue = gameManager.bossmaxHealth;
        bossHealthSlider.gameObject.SetActive(false);
        bossnametext.gameObject.SetActive(false);
    }

    void Update()
    {
        playerhealthSlider.value = gameManager.playerhealth;
        bossHealthSlider.value = gameManager.bossHealth;
        ammoText.text = "AMMO: " + gameManager.ammo;
        if (gameManager.bossBattleToggle)
        {
            bossHealthSlider.gameObject.SetActive(true);
            bossnametext.gameObject.SetActive(true);
        }
        else
        {
            bossHealthSlider.gameObject.SetActive(false);
            bossnametext.gameObject.SetActive(false);
        }
        if (gameManager.playerhealth <= 0)
        {
            ammoText.gameObject.SetActive(false);
            playerhealthSlider.gameObject.SetActive(false);
            bossHealthSlider.gameObject.SetActive(false);
            bossnametext.gameObject.SetActive(false);
            LostPanel.SetActive(true);
            Time.timeScale = 0; // Pausa o jogo
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
    public void backMenu()
    {
        SceneManager.LoadScene(0);
    }
}
