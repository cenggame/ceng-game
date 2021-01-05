using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    public GameObject confirmQuit;
    public GameObject settingsMenu;
    bool isPaused;
    bool confirm=false;
    public AudioMixer mixer;
    public AudioMixer mixerSound;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Pause_Menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Pause_Menu.SetActive(false);
        }
    }
    public void ResumeGame()
    {
        Pause_Menu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        isPaused = false;
    }
    public void Settings()
    {
        settingsMenu.SetActive(true);
        Pause_Menu.SetActiveRecursively(false);
    }
    public void Back()
    {
        settingsMenu.SetActive(false);
        Pause_Menu.SetActiveRecursively(true);
    }
    //[System.Obsolete]
    public void MainMenu()
    { 
        Pause_Menu.SetActiveRecursively(false);
        confirmQuit.SetActive(true);
        //confirm = false;
    }
    //[System.Obsolete]
    public void SelectNo()
    {
        confirmQuit.SetActive(false);
        Pause_Menu.SetActiveRecursively(true);
        confirm = false;
    }
    public void SelectYes()
    {
        if (confirm == true)
        {
            Application.Quit();
        }
        else
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        confirm = true;
        MainMenu();
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20); 
    }

    public void SetLevelSound(float sliderValue)
    {
        mixerSound.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
    }
}
