using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour
{
    public List<Button> levelButton;
    public bool delete;
    [SerializeField] Sprite lockIcon;
    private void Start()
    {
        //if (delete)
        //{
        //    PlayerPrefs.DeleteAll();
        //}
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        for (int i = 0; i < levelButton.Count; i++)
        {
            if (i <= saveIndex)
            {
                levelButton[i].interactable = true;
            }
            else
            {
                levelButton[i].image.sprite = lockIcon;
                levelButton[i].interactable = false;                
            }
        }
    }
    public SceneFader sceneFader;
    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }    
}
