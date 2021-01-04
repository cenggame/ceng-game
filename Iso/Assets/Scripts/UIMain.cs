using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;
    public GameObject soundSlider; 

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        
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
    public void SoundActive()
    {
        soundSlider.SetActive(true);
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
