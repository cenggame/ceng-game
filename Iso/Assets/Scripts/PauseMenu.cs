using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    public GameObject confirmQuit;
    bool isPaused;
    bool confirm=false;

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
        }
        else
        {
            Pause_Menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
    }
    public void Settings()
    {

    }

    [System.Obsolete]
    public void MainMenu()
    {
        Pause_Menu.SetActiveRecursively(false);
        confirmQuit.SetActive(true);
        confirm = false;
    }

    public void SelectNo()
    {
        confirmQuit.SetActive(false);
        Pause_Menu.SetActiveRecursively(true);
    }
    public void SelectYes()
    {
        if (confirm)
        {
            Application.Quit();
        }
        else
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        MainMenu();
        confirm=true;

    }
}
