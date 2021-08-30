using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public string levelToLoad = "LevelSelect 1";
    public GameObject completeLevelUI;
    public GameObject gamePanelUI;
    public GameObject defeatPanelUI;
    [SerializeField] GameObject mainPanelUI;
    [SerializeField] GameObject settingsUI;
    public SceneFader sceneFader;
    [SerializeField] float waitTime = 1f;
    public bool canShoot;
    CountDown countDown;
    int buildIndex;

    void Start()
    {
        canShoot = true;
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        countDown = FindObjectOfType<CountDown>();
    }
    public void LoadStartMenu()
    {
        sceneFader.FadeTo("StartMenu");
    }
    public void LoadLevelMenu()
    {
        sceneFader.FadeTo("LevelSelect 1");
        completeLevelUI.SetActive(false);
        gamePanelUI.SetActive(false);
    }
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void CompleteLevel()
    {
        canShoot = false;
        StartCoroutine(Complete());
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(buildIndex + 1);
        gamePanelUI.SetActive(true);
        completeLevelUI.SetActive(false);
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadGameOver()
    {
        canShoot = false;
        defeatPanelUI.SetActive(true);
        completeLevelUI.SetActive(false);
        gamePanelUI.SetActive(false);
    }
    public void Settings()
    {
        mainPanelUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainPanelUI.SetActive(true);
        settingsUI.SetActive(false);
    }
    
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(waitTime);
        defeatPanelUI.SetActive(true);
    }
    IEnumerator Complete()
    {
        yield return new WaitForSeconds(waitTime);
        completeLevelUI.SetActive(true);
        gamePanelUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
