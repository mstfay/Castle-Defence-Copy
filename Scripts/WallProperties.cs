using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProperties : MonoBehaviour
{
    [SerializeField] int maxHealt = 100;
    public int wallHealt = 100;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.75f;
    public static bool isActive = true;
    SliderControl sliderControl;
    Level level;
    MusicPlayer musicPlayer;

    UnityAds closeAd;


    void Start()
    {
        closeAd = FindObjectOfType<UnityAds>();
        sliderControl = FindObjectOfType<SliderControl>();
        level = FindObjectOfType<Level>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        WallProperties.isActive = true;
        if (SaveGame.HaveASaveHealt() == true)
        {
            wallHealt = SaveGame.ReadHealt();
            maxHealt = SaveGame.ReadHealt();
        }
        else
        {
            maxHealt = 100;
            wallHealt = 100;
        }
    }
    /// <summary>
    /// Duvara mermi çarptığını algılar.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        Enemy damage = collision.gameObject.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Projectile")
        {
            ProcessHit(damageDealer);
        }
        if (gameObject.tag == "Sword")
        {
            TakeDamage(damage.attackDamage);
        }

    }

    public int GetHealt()
    {
        return wallHealt;
    }

    /// <summary>
    /// Duvara çarpan merminin hasarını geri bildirir. Candan düşer.
    /// </summary>
    /// <param name="damageDealer"></param>
    void ProcessHit(DamageDealer damageDealer)
    {
        wallHealt -= damageDealer.GetProjectileDamage();
        sliderControl.HealtValue(maxHealt, maxHealt - wallHealt);
        damageDealer.Hit();
        if (wallHealt <= 0)
        {
            closeAd.CloseBannerAd();
            isActive = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("HealtCanvas");
            foreach (GameObject enemy in enemies) {GameObject.Destroy(enemy);}
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
            level.LoadGameOver();
            musicPlayer.StopMusic();
        }
    }
    /// <summary>
    /// Can değeri 0 ise HealtCanvas tag' i olan oyun objesini oyundan kaldırır. Oyunu kaybedince ekranda healtbar kaybolur.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        wallHealt -= damage;
        sliderControl.HealtValue(maxHealt, maxHealt - wallHealt);
        if (wallHealt <= 0)
        {
            closeAd.CloseBannerAd();
            isActive = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("HealtCanvas");
            foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
            level.LoadGameOver();
            musicPlayer.StopMusic();
        }
    }    
}
