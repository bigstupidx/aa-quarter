﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresistanceObject : MonoBehaviour {

	public string txtString = "Let's start";
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	public void ChangeTxt(string txtDisplay){
		txtString = txtDisplay;
	}
}
