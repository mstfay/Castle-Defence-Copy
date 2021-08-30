using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public static bool isLevelCompleted = false;
    public static bool isGameStarted = false;
    public bool isGameEnded = false;

    Level level;
    public int thisGold;
    int buildIndex;    
    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        level = FindObjectOfType<Level>();
        if (PlayerPrefs.HasKey(SaveGame.gold))
        {
            thisGold = SaveGame.ReadGold();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        isGameStarted = true;
        SetUpSingleton();
    }

    void SetUpSingleton()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetGold()
    {
        return thisGold;
    }

    public void AddToGold(int goldValue)
    {
        thisGold = SaveGame.ReadGold() + goldValue;
        SaveGame.SaveGold(thisGold);
    }

    void ResetGame()
    {
        Destroy(gameObject);
    }

    public void LevelBitti()
    {
        if (buildIndex > PlayerPrefs.GetInt("SaveIndex"))
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }        
        level.CompleteLevel();
        isGameEnded = true;
        ResetGame();
    }
}
