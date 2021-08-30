using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject englishPanelUI;
    [SerializeField] GameObject turkishPanelUI;
    [SerializeField] GameObject russianPanelUI;
    [SerializeField] GameObject germanyPanelUI;
    MusicPlayer musicPlayer;

    string language;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        language = SaveGame.ReadSelectedLanguage();
        musicPlayer.StopMusic();

        if (language == "English")
        {
            englishPanelUI.SetActive(true);
            turkishPanelUI.SetActive(false);
            russianPanelUI.SetActive(false);
            germanyPanelUI.SetActive(false);
        }
        if (language == "Turkish")
        {
            englishPanelUI.SetActive(false);
            turkishPanelUI.SetActive(true);
            russianPanelUI.SetActive(false);
            germanyPanelUI.SetActive(false);
        }
        if (language == "Russian")
        {
            englishPanelUI.SetActive(false);
            turkishPanelUI.SetActive(false);
            russianPanelUI.SetActive(true);
            germanyPanelUI.SetActive(false);
        }
        if (language == "Germany")
        {
            englishPanelUI.SetActive(false);
            turkishPanelUI.SetActive(false);
            russianPanelUI.SetActive(false);
            germanyPanelUI.SetActive(true);
        }
    }
}
