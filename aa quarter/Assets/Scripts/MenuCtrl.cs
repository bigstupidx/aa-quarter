﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {

	public Text successFaild;
	public Text LevelTxt;
	private int storedLevel;
	public Text nextRetry;
	public void LoadScene(string scene){
		SceneManager.LoadScene (scene);
	}

	void Start() {
		//PlayerPrefs.DeleteAll ();
		storedLevel = PlayerPrefs.GetInt ("Level",1);
		LevelTxt.text = "Level " + storedLevel;
		successFaild.text = FindObjectOfType<PresistanceObject> ().txtString;
		if (successFaild.text == "Faild!!") {
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
	void Update(){
		storedLevel = PlayerPrefs.GetInt ("Level",1);
		LevelTxt.text = "Level " + storedLevel;
	}
	public void ResetLevels(){
		PlayerPrefs.SetInt ("Level",1);
	
	}
}
