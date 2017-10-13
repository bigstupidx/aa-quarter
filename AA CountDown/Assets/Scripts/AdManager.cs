using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class AdManager : MonoBehaviour {

	public static AdManager Instance { get; private set; }

	private void Awake(){
		Instance = this;
	}

	public void ShowUnityAd(string placementId, bool enableCallback){
#if UNITY_ADS
		if (!Advertisement.IsReady (placementId)) {
			Debug.LogWarning ("ad is not ready" + placementId);
		} else {
			ShowOptions options = new ShowOptions ();
			if (enableCallback) {
				options.resultCallback = OnAd_Result;
				Advertisement.Show (placementId,options);
			}
		}
#endif
	}
#if UNITY_ADS
	private void OnAd_Result(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			Debug.Log ("Ad was show successfully and played ..");
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad was shown but skipped");
			break;
		case ShowResult.Failed:
			Debug.Log ("Ad display failed");
			break;
		}
	}
#endif
}
