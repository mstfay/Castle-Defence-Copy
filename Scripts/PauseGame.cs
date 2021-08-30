using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public string loadStartMenu = "StartMenu";
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public SceneFader sceneFader;

    /// <summary>
    /// Oyunu devam ettiren kod bloğu.
    /// </summary>
    public void Resume()
    {        
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Oyunu durduran kod bloğu.
    /// </summary>
    public void Pause()
    {
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Başlangıç ekranına döndüren kod bloğu.
    /// </summary>
    public void StartMenu()
    {
        pauseMenuUI.SetActive(false);
        sceneFader.FadeTo(loadStartMenu);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Oyundan çıkış yaptıran kod bloğu.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
