using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour {
	public static AdmobManager instance = null;
	public string Android_Admob_Banner_ID_Test; // ca-app-pub-3940256099942544/6300978111
	public string Android_Admob_Banner_ID_Prod; // for production
	public string IOS_Admob_Banner_ID_Prod; // for production
	public bool testMode;
	BannerView bannerView;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		RequestBanner ();
	}
	
	public void RequestBanner(){
		if (testMode) {
			bannerView = new BannerView (Android_Admob_Banner_ID_Test, AdSize.Banner, AdPosition.Bottom);
		} else {
			#if UNITY_IOS
			bannerView = new BannerView (IOS_Admob_Banner_ID_Prod, AdSize.Banner, AdPosition.Bottom);
			#endif
			#if UNITY_ANDROID
			bannerView = new BannerView (Android_Admob_Banner_ID_Prod, AdSize.Banner, AdPosition.Bottom);
			#endif
		}
		AdRequest adRequest = new AdRequest.Builder ().Build ();
		bannerView.LoadAd (adRequest);
	}
}
