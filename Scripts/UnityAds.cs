using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    public Button adButton, adButton2;

    public bool TestMode = true;

    public string AndroidID = "4205748";
    public string IOSID = "4205749";

    private string RewadedID = "Rewarded_Android";
    private string InterstitialID = "Interstitial_Android";
    private string BannerID = "Banner_Android";
    int buildIndex;

    int gold;

    // Start is called before the first frame update
    void Awake()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;

        Advertisement.AddListener(this);
#if UNITY_ANDROID
        Advertisement.Initialize(AndroidID, TestMode);
#else
        Advertisement.Initialize(IOSID, TestMode);
#endif

        ShowBannerAd();
        if (buildIndex == 0 || buildIndex == 31 || buildIndex == 32 || buildIndex == 33)
        {
            CloseBannerAd();
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(RewadedID))
        {
            Advertisement.Show(RewadedID);
        }
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady(InterstitialID))
        {
            Advertisement.Show(InterstitialID);
        }
    }

    public void ShowBannerAd()
    {
        if (Advertisement.IsReady(BannerID))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(BannerID);
        }
    }
    public void CloseBannerAd()
    {
        Advertisement.Banner.Hide();        
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message){ }

    public void OnUnityAdsDidStart(string placementId)
    {
        Time.timeScale = 0f;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Time.timeScale = 1f;
        if (placementId == RewadedID)
        {
            if (showResult == ShowResult.Finished)
            {
                adButton.interactable = false;
                adButton2.interactable = false;
                gold = SaveGame.ReadGold() + 200;
                SaveGame.SaveGold(gold);                
            }
            else if (showResult == ShowResult.Skipped)
            {
                gold = SaveGame.ReadGold();
            }
            else if (showResult == ShowResult.Failed)
            {
                gold = SaveGame.ReadGold();
            }
        }
    }
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}

