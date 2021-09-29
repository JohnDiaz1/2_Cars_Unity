using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;


public class Banner : MonoBehaviour
{
    string adUnitId = "ca-app-pub-3254757154675329/8984050609";
    private BannerView bannerView;

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
        
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

    }
    
}
