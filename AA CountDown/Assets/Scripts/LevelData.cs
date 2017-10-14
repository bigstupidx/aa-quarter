using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {
	public bool directionSwap;
	public float pinSpeed = 20;
	public float circleSpeed = 80;
	public bool clockwise = true;
	public bool toChangeSpeed;
	public float speedMin = 60;
	public float speedMax = 120;
	public string orange1txt;
	public string blue1txt;
	public string orange2txt;
	public string blue2txt;
	public bool[] activePins = new bool[8];

}