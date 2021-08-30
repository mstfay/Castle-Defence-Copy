using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageSelecter : MonoBehaviour
{
    [HideInInspector] public List<Text> TextsInScene;

    public List<TranslaterInScene> Translates;

    int scene;

    string English;

    public Button english, turkish, russian, germany;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        foreach (Text items in Resources.FindObjectsOfTypeAll(typeof(Text)))
        {
            TextsInScene.Add(items);
            if (SaveGame.HaveASaveLanguage() == true)
            {
                Translate(SaveGame.ReadSelectedLanguage());
                if (SaveGame.ReadSelectedLanguage() == "English")
                {
                    if (scene == 0)
                    {
                        english.interactable = false;
                        turkish.interactable = true;
                        russian.interactable = true;
                        germany.interactable = true;
                    }
                }
                else if (SaveGame.ReadSelectedLanguage() == "Turkish")
                {
                    if (scene == 0)
                    {
                        english.interactable = true;
                        turkish.interactable = false;
                        russian.interactable = true;
                        germany.interactable = true;
                    }
                }
                else if (SaveGame.ReadSelectedLanguage() == "Russian")
                {
                    if (scene == 0)
                    {
                        english.interactable = true;
                        turkish.interactable = true;
                        russian.interactable = false;
                        germany.interactable = true;
                    }
                }
                else
                {
                    if (scene == 0)
                    {
                        english.interactable = true;
                        turkish.interactable = true;
                        russian.interactable = true;
                        germany.interactable = false;
                    }
                }
            }
            else
            {
                    if (scene == 0)
                {
                    english.interactable = false;
                    turkish.interactable = true;
                    russian.interactable = true;
                    germany.interactable = true;
                }
            }
        }        
    }

    public void Translate(string ToLanguage)
    {
        for (int i = 0; i < Translates.Count; i++)
        {
            for (int s = 0; s < TextsInScene.Count; s++)
            {
                if (ToLanguage == "English")
                {
                    if (Translates[i].Turkish == TextsInScene[s].text || Translates[i].Russian == TextsInScene[s].text || Translates[i].Germany == TextsInScene[s].text)
                    {
                        TextsInScene[s].text = Translates[i].English;
                        SaveGame.SaveSelectedLanguage(ToLanguage);
                        if(scene == 0)
                        {
                            english.interactable = false;
                            turkish.interactable = true;
                            russian.interactable = true;
                            germany.interactable = true;
                        }                        
                    }                                       
                }

                else if (ToLanguage == "Turkish")
                {
                    if (Translates[i].English == TextsInScene[s].text || Translates[i].Russian == TextsInScene[s].text || Translates[i].Germany == TextsInScene[s].text)
                    {
                        TextsInScene[s].text = Translates[i].Turkish;
                        SaveGame.SaveSelectedLanguage(ToLanguage);
                        if (scene == 0)
                        {
                            english.interactable = true;
                            turkish.interactable = false;
                            russian.interactable = true;
                            germany.interactable = true;
                        }
                    }
                }

                else if (ToLanguage == "Russian")
                {
                    if (Translates[i].English == TextsInScene[s].text || Translates[i].Turkish == TextsInScene[s].text || Translates[i].Germany == TextsInScene[s].text)
                    {
                        TextsInScene[s].text = Translates[i].Russian;
                        SaveGame.SaveSelectedLanguage(ToLanguage);
                        if (scene == 0)
                        {
                            english.interactable = true;
                            turkish.interactable = true;
                            russian.interactable = false;
                            germany.interactable = true;
                        }
                    }
                }
                
                else
                {
                    if (Translates[i].English == TextsInScene[s].text || Translates[i].Russian == TextsInScene[s].text || Translates[i].Turkish == TextsInScene[s].text)
                    {
                        TextsInScene[s].text = Translates[i].Germany;
                        SaveGame.SaveSelectedLanguage(ToLanguage);
                        if (scene == 0)
                        {
                            english.interactable = true;
                            turkish.interactable = true;
                            russian.interactable = true;
                            germany.interactable = false;
                        }
                    }
                }
            }

        }
    }

    public void ChangeLanguage(string Language)
    {
        Translate(Language);
    }
    // Update is called once per frame
    void Update()
    {
        
    }    
}
[System.Serializable]
public class TranslaterInScene
{
    public string English;
    public string Turkish;
    public string Russian;
    public string Germany;

    public TranslaterInScene(string english, string turkish, string russian, string germany)
    {
        English = english;
        Turkish = turkish;
        Russian = russian;
        Germany = germany;
    }
}
