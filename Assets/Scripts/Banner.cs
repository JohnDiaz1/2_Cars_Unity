using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banner : MonoBehaviour
{
    string bannerAdUnitId = "ec55e9088c51da68";

    //ca-app-pub-3120121289944186/2529644622 banner real
    //ca-app-pub-3120121289944186/6041019385 Intersical real
    //string appId = "ca-app-pub-3120121289944186/2529644622";

    // Start is called before the first frame update
    
    void Start()
    {       

    if(PlayerPrefs.GetInt("ads") != 1){

        this.RequestBanner();

        }
    }

    private void RequestBanner()
    {
        // Adaptive banners are sized based on device width for positions that stretch full width (TopCenter and BottomCenter).
    // You may use the utility method `MaxSdkUtils.GetAdaptiveBannerHeight()` to help with view sizing adjustments
    MaxSdk.CreateBanner(bannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);
    MaxSdk.SetBannerExtraParameter(bannerAdUnitId, "adaptive_banner", "true");

    MaxSdk.ShowBanner(bannerAdUnitId);

    }
    
}
