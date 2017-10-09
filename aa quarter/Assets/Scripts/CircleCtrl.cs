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
	// Use this for initialization
	void Start () {
		currentLevel = PlayerPrefs.GetInt ("Level", 1);
		dataController = FindObjectOfType<DataController> ();
		levelData = dataController.GetCurrentLevelData (currentLevel);
		speed = levelData.circleSpeed;
		activePins = levelData.activePins;
		for (int i = 0; i < 32; i++) {
			if (activePins [i] == 0) {
				staticPins [i].SetActive(false);
				Debug.Log (i);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f,0f,speed * Time.deltaTime);
	}
}
