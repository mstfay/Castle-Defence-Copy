using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame
{
    public static string gold = "goldKey";
    public static string attackDamage = "attackDamageKey";
    public static string movementSpeed = "movementSpeedKey";
    public static string healt = "healtKey";
    public static string arrow = "arrowKey";
    public static string volume = "volumeKey";

    public static string attackQuantity = "attackQuantityKey";
    public static string speedQuantity = "speedQuantityKey";
    public static string healtQuantity = "healtQuantityKey";
    public static string arrowQuantity = "arrowQuantityKey";
    public static string language = "languageKey";

    public static string numberOfClick = "numberOfClickKey";

    /// <summary>
    /// Reklam için tıklama sayısı kaydeder.
    /// </summary>
    /// <param name="gold"></param>
    public static void SaveClick(int numberOfClick)
    {
        PlayerPrefs.SetInt(SaveGame.numberOfClick, numberOfClick);
    }

    public static int ReadClick()
    {
        return PlayerPrefs.GetInt(SaveGame.numberOfClick);
    }
    /// <summary>
    /// Altın Kaydetme
    /// </summary>
    /// <param name="gold"></param>
    public static void SaveGold(int gold)
    {
        PlayerPrefs.SetInt(SaveGame.gold, gold);
    }

    public static int ReadGold()
    {
        return PlayerPrefs.GetInt(SaveGame.gold);
    }
    public static void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat(SaveGame.volume, volume);
    }
    public static float ReadVolume()
    {
        return PlayerPrefs.GetFloat(SaveGame.volume);
    }
    /// <summary>
    /// Hasar Kaydetme
    /// </summary>
    /// <param name="attackDamage"></param>
    public static void SaveAttackDamage(int attackDamage)
    {
        PlayerPrefs.SetInt(SaveGame.attackDamage, attackDamage);
    }

    public static int ReadAttackDamage()
    {
        return PlayerPrefs.GetInt(SaveGame.attackDamage);
    }

    /// <summary>
    /// Can Kaydetme
    /// </summary>
    /// <param name="healt"></param>
    public static void SaveHealt(int healt)
    {
        PlayerPrefs.SetInt(SaveGame.healt, healt);
    }

    public static int ReadHealt()
    {
        return PlayerPrefs.GetInt(SaveGame.healt);
    }
    /// <summary>
    /// Koşma Hızı Kayıt
    /// </summary>
    /// <param name="speed"></param>
    public static void SaveMovementSpeed(float speed)
    {
        PlayerPrefs.SetFloat(SaveGame.movementSpeed, speed);
    }    

    public static float ReadMovementSpeed()
    {
        return PlayerPrefs.GetFloat(SaveGame.movementSpeed);
    }
    /// <summary>
    /// Ok Sayısı Kayıt
    /// </summary>
    /// <param name="numberOfArrow"></param>
    public static void SaveNumberOfArrows(int numberOfArrow)
    {
        PlayerPrefs.SetInt(SaveGame.arrow, numberOfArrow);
    }

    public static int ReadNumberOfArrows()
    {
        return PlayerPrefs.GetInt(SaveGame.arrow);
    }
    /// <summary>
    /// Dil seçeneği kayıt.
    /// </summary>
    /// <param name="language"></param>
    public static void SaveSelectedLanguage(string language)
    {
        PlayerPrefs.SetString(SaveGame.language, language);
    }

    public static string ReadSelectedLanguage()
    {
        return PlayerPrefs.GetString(SaveGame.language);
    }
    /// <summary>
    /// Altın kayıt var mı sorgular.
    /// </summary>
    /// <returns></returns>
    public static bool HaveASaveGold()
    {        
        if (PlayerPrefs.HasKey(SaveGame.gold))
        {
            return true;
        }
        else
        {
            return false;
        }       
    }
    /// <summary>
    /// Attack Damage satın alınmasını kontrol eder.
    /// </summary>
    /// <returns></returns>
    public static bool HaveASaveDamage()
    {
        if (PlayerPrefs.HasKey(SaveGame.attackDamage))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Yürüme hızı satın alınmasını kontrol eder.
    /// </summary>
    /// <returns></returns>
    public static bool HaveASaveMovement()
    {
        if (PlayerPrefs.HasKey(SaveGame.movementSpeed))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Can satın alınmasını kontrol eder.
    /// </summary>
    /// <returns></returns>
    public static bool HaveASaveHealt()
    {
        if (PlayerPrefs.HasKey(SaveGame.healt))
        {
            return true;
        }
        else
        {
            return false;
        }
    }    
    /// <summary>
    /// Ekstra ok satın alınmasını kontrol eder.
    /// </summary>
    /// <returns></returns>
    public static bool HaveASaveArrow()
    {
        if (PlayerPrefs.HasKey(SaveGame.arrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// null
    /// </summary>
    /// <param name="itemQuantity"></param>
    public static void SaveAttackQuantity(int attackQuantity)
    {
        PlayerPrefs.SetInt(SaveGame.attackQuantity, attackQuantity);
    }

    public static int ReadAttackQuantity()
    {
        return PlayerPrefs.GetInt(SaveGame.attackQuantity);
    }

    public static void SaveSpeedQuantity(int speedQuantity)
    {
        PlayerPrefs.SetInt(SaveGame.speedQuantity, speedQuantity);
    }

    public static int ReadSpeedQuantity()
    {
        return PlayerPrefs.GetInt(SaveGame.speedQuantity);
    }

    public static void SaveHealtQuantity(int healtQuantity)
    {
        PlayerPrefs.SetInt(SaveGame.healtQuantity, healtQuantity);
    }

    public static int ReadHealtQuantity()
    {
        return PlayerPrefs.GetInt(SaveGame.healtQuantity);
    }

    public static void SaveArrowQuantity(int arrowQuantity)
    {
        PlayerPrefs.SetInt(SaveGame.arrowQuantity, arrowQuantity);
    }

    public static int ReadArrowQuantity()
    {
        return PlayerPrefs.GetInt(SaveGame.arrowQuantity);
    }

    public static bool HaveASaveAttackQuantity()
    {
        if (PlayerPrefs.HasKey(SaveGame.attackQuantity))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HaveASaveSpeedQuantity()
    {
        if (PlayerPrefs.HasKey(SaveGame.speedQuantity))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HaveASaveHealtQuantity()
    {
        if (PlayerPrefs.HasKey(SaveGame.healtQuantity))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HaveASaveArrowQuantity()
    {
        if (PlayerPrefs.HasKey(SaveGame.arrowQuantity))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool HaveASaveVolume()
    {
        if (PlayerPrefs.HasKey(SaveGame.volume))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HaveASaveLanguage()
    {
        if (PlayerPrefs.HasKey(SaveGame.language))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Geçiş reklamı için tıklama sayısını kontrol eder.
    /// </summary>
    /// <returns></returns>
    public static bool HaveASaveClick()
    {
        if (PlayerPrefs.HasKey(SaveGame.numberOfClick))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
