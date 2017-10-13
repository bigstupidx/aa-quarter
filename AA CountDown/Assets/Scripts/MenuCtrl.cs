using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {

	public Text successFaild;
	public Text LevelTxt;
	private int storedLevel;
	public Text nextRetry;
	public Text levelToReplay;
	public Text errorTxt;
	public GameObject replayLevelCanvas;

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
			successFaild.fontSize = 80;
			nextRetry.text = "Next...";
			nextRetry.color = Color.green;
			successFaild.color = Color.green;
		}
	}

	public void LoadScene(string scene){
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
					replayLevelCanvas.SetActive (false);
				} else {
					errorTxt.text = "That level has not been passed yet!";
					//for testing
					//TODO remove when publish
					PlayerPrefs.SetInt ("Level", gotoLevel);
					replayLevelCanvas.SetActive (false);
				}
			} else {
				errorTxt.text =  "Plaese enter a positive number";
			}
		} else {
			errorTxt.text =  "Plaese enter a number";
		}
	}
}
