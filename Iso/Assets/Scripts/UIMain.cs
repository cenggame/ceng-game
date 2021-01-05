using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIMain : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;
    public GameObject soundScreen;
    public AudioMixer soundMixer;
    public AudioMixer musicMixer;
    

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void SoundScreen()
    {
        settingsScreen.SetActive(false);
        soundScreen.SetActive(true);
    }
    public void SetToSettings()
    {
        settingsScreen.SetActive(true);
        soundScreen.SetActive(false);
    }
    public void SetToMenu()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void Credits()
    {
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void CreToMenu()
    {
        mainScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void SetLevelMusic(float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelSound(float sliderValue)
    {
        soundMixer.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
