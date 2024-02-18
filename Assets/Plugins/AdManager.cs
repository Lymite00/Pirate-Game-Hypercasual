using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private BannerView _bannerView;
    void Start()
    {
        MobileAds.Initialize(status => {});
        this.RequestBanner();
    }

    void RequestBanner()
    {
#if UNITY_ANDROID
        string reklamID = "ca-app-pub-3940256099942544/6300978111";

#elif UNITY_IPHONE
        string reklamID = "ca-app-pub-3940256099942544/2934735716";
#else
        string reklamID = "unexpected_platform";
#endif
        this._bannerView = new BannerView(reklamID, AdSize.Banner, AdPosition.Bottom);
        
        AdRequest request = new AdRequest.Builder().Build();
        
        this._bannerView.LoadAd(request);
    }

    void Update()
    {
        
    }
}
