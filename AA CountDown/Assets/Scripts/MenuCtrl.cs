using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class MenuCtrl : MonoBehaviour {

	public Text successFaild;
	public Text LevelTxt;
	private int storedLevel;
	public Text nextRetry;
	public Text levelToReplay;
	public Text errorTxt;
	//public bool isTest = false; //TODO remove when public
	public GameObject replayLevelCanvas;
	public Button btn_play;

	private int lastLevel;

	void Start() {
		//PlayerPrefs.DeleteAll ();
		storedLevel = PlayerPrefs.GetInt ("Level",1);
		LevelTxt.text = "Level " + storedLevel;
		successFaild.text = FindObjectOfType<PresistanceObject> ().txtString;
		if (successFaild.text == "Failed!!") {
			successFaild.fontSize = 80;
			nextRetry.text = "Retry...";
			nextRetry.color = Color.red;
			successFaild.color = Color.red;
		} else if(successFaild.text == "Success!!"){
			lastLevel = PlayerPrefs.GetInt ("lastLevel");
			if (storedLevel < lastLevel) {
				successFaild.fontSize = 80;
				nextRetry.text = "Next...";
				nextRetry.color = Color.green;
				successFaild.color = Color.green;
			} else {
				successFaild.text = "  CONGRATULATIONS YOU REACHED THE LAST LEVEL  ";
				successFaild.fontSize = 25;
				nextRetry.text = "More Levels Coming Soon..";
				nextRetry.fontSize = 25;
				nextRetry.color = Color.green;
				successFaild.color = Color.green;
				btn_play.interactable = false;
			}

		}
	}

	public void LoadScene(string scene){
		int adsCount;
		adsCount = PlayerPrefs .GetInt("adsCount",5);
		if (adsCount <= 0) {
			AdManager.Instance.ShowUnityAd ("video", true);
			PlayerPrefs.SetInt ("adsCount",5);
		} else {
			adsCount--;
			PlayerPrefs.SetInt ("adsCount",adsCount);
		}
		SceneManager.LoadScene (scene);
	}

	void Update(){
		storedLevel = PlayerPrefs.GetInt ("Level",1);
		LevelTxt.text = "Level " + storedLevel;
	}
	public void ResetLevels(){
		PlayerPrefs.SetInt ("Level",1);
	
	}
	public void ReplayLevelScreen(){
		errorTxt.text = "";
		replayLevelCanvas.SetActive(true);
	}
	public void ReplayLevel(bool toReplay){
		if (!toReplay) {
			replayLevelCanvas.SetActive(false);
			return;
		}
		int gotoLevel;
		if (int.TryParse (levelToReplay.text, out gotoLevel)) {
			if (gotoLevel > 0) {
				int maxLevel = PlayerPrefs.GetInt ("MaxLevel", 1);
				if (gotoLevel <= maxLevel) {
					PlayerPrefs.SetInt ("Level", gotoLevel);
					btn_play.interactable = true;
					replayLevelCanvas.SetActive (false);
				} else {
					errorTxt.text = "That level has not been passed yet!";
				}
			} else {
				errorTxt.text =  "Plaese enter a positive number";
			}
		} else {
			errorTxt.text =  "Plaese enter a number";
		}
	}

}
