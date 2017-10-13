using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {
	public int levelNumber;
	public int direction;
	public float pinSpeed;
	public float circleSpeed;
	public bool toChangeSpeed;
	public float speedMin;
	public float speedMax;
	public string orange1txt;
	public string blue1txt;
	public string orange2txt;
	public string blue2txt;
	public int[] activePins;
}