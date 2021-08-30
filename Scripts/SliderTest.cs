using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderTest : MonoBehaviour
{
    public AudioSource audioSource;

    public float musicVolume = 100f;

    public Slider slider;

    [SerializeField] Text volumeText;

    void Awake()
    {
        if (SaveGame.HaveASaveVolume() == true)
        {
            musicVolume = SaveGame.ReadVolume() * 100;
            slider.value = SaveGame.ReadVolume() * 100;
            volumeText.text = " % " + ((int)(SaveGame.ReadVolume() * 100)).ToString();
        }
        else
        {
            musicVolume = 100f;
        }
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
    }

    void Update()
    {
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
        audioSource.volume = musicVolume;        
    }
    public void volumeUpdate(float volume)
    {
        musicVolume = volume / 100;
        SaveGame.SaveVolume(musicVolume);
        volumeText.text = " % " + ((int)(100 * musicVolume)).ToString();        
    }
}
