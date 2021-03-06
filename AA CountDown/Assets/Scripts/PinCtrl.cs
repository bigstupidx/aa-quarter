﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PinCtrl : MonoBehaviour {
	public float speed = 20f;
	public Rigidbody2D rb;
	private Text txt;
	private bool isPinned = false;
	private GameObject circle;
	private int toChangeSpeed;
	private Text[] countTxt;
	private PresistanceObject presistanceObject;
	private GameCtrl gameCtrl;
	private int currentLevel;
	private int nextLevel;
	private bool gameEnded = false;
	private DataController dataController;
	private LevelData levelData;
	private int direction = 1;
	private AudioSource[] myAudio;
	private int maxLevel;
	private int isSuccess;
	void Start(){
		isSuccess = 0;
		myAudio = gameObject.GetComponents<AudioSource> ();
		currentLevel = PlayerPrefs.GetInt ("Level", 1);
		circle = GameObject.FindGameObjectWithTag("Rotator");
		countTxt = circle.GetComponentsInChildren<Text> ();
		presistanceObject = FindObjectOfType<PresistanceObject> ();
		gameCtrl = FindObjectOfType<GameCtrl> ();
		dataController = FindObjectOfType<DataController> ();
		levelData = dataController.GetCurrentLevelData (currentLevel);
		direction = levelData.directionSwap;
		toChangeSpeed = levelData.toChangeSpeed;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (!isPinned)
			rb.MovePosition (rb.position + Vector2.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("orange1") || col.CompareTag ("orange2") || col.CompareTag ("blue1") || col.CompareTag ("blue2")) {
			txt = col.GetComponentInChildren<Text> ();
			CircleCtrl circleCtrl = col.GetComponentInParent<CircleCtrl> ().GetComponent<CircleCtrl> ();
			int current;
			int.TryParse (txt.text, out current);
			transform.SetParent (col.transform);
			isPinned = true;
			if (current <= 0) {
				gameEnded = true;
				presistanceObject.ChangeTxt ("Failed!!");
				gameCtrl.EndGame (false);
				StartCoroutine ("Wait");
				myAudio[1].Play ();
				return;
			}
			myAudio[0].Play();
			current--;
			txt.text = current.ToString ();
			circleCtrl.speed *= direction;
			if (toChangeSpeed == 1) {
				circleCtrl.ChangeSpeed ();
			}

		} else if (col.CompareTag("Pin") && rb.transform.position.y > -2.0f) {
			isSuccess = -1;
			StartCoroutine ("WaitBeforDecide");
		}
		if (!gameEnded) {
			GameEndedWithSuccess ();
		}
	}
	void GameEndedWithSuccess(){
		if (countTxt[0].text == "0" && countTxt[1].text == "0" && countTxt[2].text == "0" && countTxt[3].text == "0") {
			if (isSuccess == 0) {
				gameCtrl.StopSpawner ();
				isSuccess = 1;
			}
			StartCoroutine ("WaitBeforDecide");
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.7f);
		SceneManager.LoadScene ("Menu");
	}
	IEnumerator WaitBeforDecide()
	{
		yield return new WaitForSeconds(0.01f);
		if (isSuccess == 1) {
			myAudio[2].Play ();
			gameEnded = true;
			nextLevel = PlayerPrefs.GetInt ("Level", 1) + 1;
			maxLevel = PlayerPrefs.GetInt ("MaxLevel",1);
			if (nextLevel > maxLevel) {
				PlayerPrefs.SetInt ("MaxLevel", nextLevel);
			}
			PlayerPrefs.SetInt ("Level", nextLevel);
			presistanceObject.ChangeTxt("Success!!");
			gameCtrl.EndGame(true);
			StartCoroutine("Wait");
		} else if(isSuccess == -1){
			myAudio[1].Play ();
			gameEnded = true;
			presistanceObject.ChangeTxt ("Failed!!");
			gameCtrl.EndGame (false);
			StartCoroutine ("Wait");
		}

	}
}
