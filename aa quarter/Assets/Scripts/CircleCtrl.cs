using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCtrl : MonoBehaviour {
	public float speed = 100f;
	private int currentLevel;
	private DataController dataController;
	private LevelData levelData;
	public GameObject[] staticPins;
	public int[] activePins;
	private int speedUp = 1;
	private float minSpeed;
	private float maxSpeed;
	// Use this for initialization
	void Start () {
		currentLevel = PlayerPrefs.GetInt ("Level", 1);
		dataController = FindObjectOfType<DataController> ();
		levelData = dataController.GetCurrentLevelData (currentLevel);
		speed = levelData.circleSpeed;
		minSpeed = levelData.speedMin;
		maxSpeed = levelData.speedMax;
		activePins = levelData.activePins;
		for (int i = 0; i < 32; i++) {
			if (activePins [i] == 0) {
				staticPins [i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f,0f,speed * Time.deltaTime);
	}

	public void ChangeSpeed(){
		if (speed > maxSpeed || speed < minSpeed) {
			speedUp *= -1;
		}
		speed += 20f * speedUp;
	}
}
