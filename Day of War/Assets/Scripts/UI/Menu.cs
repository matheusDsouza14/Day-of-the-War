using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
    public GameObject settingsText;
    [SerializeField] private int devmenucounter;
    public GameObject DevMenuPanel;
    public GameObject SettingsMenuPanel;
    public GameObject startMenuPanel;
    public TextMeshProUGUI volumePer;
    public TextMeshProUGUI graphicsShow;
    public Slider volumeSlider;
    public Slider graphicsSlider;
    public Toggle InfiniteAmmo;
    public Toggle InfiniteHealth;
    void Start()
    {
        volumeSlider.minValue = 0;
        volumeSlider.maxValue = 100;
        volumeSlider.value = volumeSlider.maxValue;
        graphicsSlider.value = graphicsSlider.maxValue;
    }
    void Update()
    {
        volumePer.text = volumeSlider.value.ToString()+"%";
        SliderGraphics();
    }
    public void DevMenu()
    {
        devmenucounter++;
        if(devmenucounter==200)
        {
            SettingsMenuPanel.SetActive(false);
            startMenuPanel.SetActive(false);
            DevMenuPanel.SetActive(true);
        }
    }
    public void SliderGraphics()
    {
        if(graphicsSlider.value == 0)
        {
            graphicsShow.text = "Low";
            QualitySettings.SetQualityLevel(0);
        }else if(graphicsSlider.value == 25)
        {
            graphicsShow.text = "Medium";
            QualitySettings.SetQualityLevel(1);
        }
        else if (graphicsSlider.value == 50)
        {
            graphicsShow.text = "High";
            QualitySettings.SetQualityLevel(2);
        }
        else if (graphicsSlider.value == 75)
        {
            graphicsShow.text = "Very High";
            QualitySettings.SetQualityLevel(3);
        }
        else if (graphicsSlider.value == 100)
        {
            graphicsShow.text = "Ultra";
            QualitySettings.SetQualityLevel(4);
        }
    }
    public void StageSelector(int stage)
    {
        if (stage == 1)
        {
            SceneManager.LoadScene(1);
        }else if (stage == 2)
        {
            SceneManager.LoadScene(2);
        }
    }
}
