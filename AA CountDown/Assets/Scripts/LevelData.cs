using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {
	public int directionSwap = 0; // 1 or -1
	public float circleSpeed = 80;
	public int toChangeSpeed = 0; // 0 or 1
	public float speedMin = 60;
	public float speedMax = 120;
	public int numbers = 1111;
	public int[] activePins;

}