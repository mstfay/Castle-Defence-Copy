using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;
    public AudioSource audioSource;

    void Awake()
    {
        if (SaveGame.HaveASaveVolume() == true)
        {
            audioSource.volume = SaveGame.ReadVolume();
        }
        else
        {
            audioSource.volume = 80f;
        }
        SetUpSingleton();

    }

    void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);         
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }    

    public void StopMusic()
    {
        if (audioSource != null) 
        {
            Destroy(gameObject);
        }        
    }
}
