using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCtrl : MonoBehaviour {

	public string levelNumber;
	public int rotationDirection;
	public Text orange1Txt;
	public Text blue1Txt;
	public Text orange2Txt;
	public Text blue2Txt;
	private int currentLevel;
	private DataController dataController;
	private LevelData levelData;

	void Start () {
		currentLevel = PlayerPrefs.GetInt ("Level", 1);
		dataController = FindObjectOfType<DataController> ();
		levelData = dataController.GetCurrentLevelData (currentLevel);
		orange1Txt.text = levelData.orange1txt;
		orange2Txt.text = levelData.orange2txt;
		blue1Txt.text = levelData.blue1txt;
		blue2Txt.text = levelData.blue2txt;
	}
}
