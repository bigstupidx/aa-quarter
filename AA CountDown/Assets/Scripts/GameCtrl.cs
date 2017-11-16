using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour {

	private bool gameHasEnded = false;
	public CircleCtrl rotator;
	public Spawner spawner;
	public Animator animator;
	public void EndGame(bool isSuccess){
		if (gameHasEnded) {
			return;
		}

		rotator.enabled = false;
		spawner.enabled = false;
		if (isSuccess) {
			animator.SetTrigger ("EndGameSuccess");
		} else {
			animator.SetTrigger ("EndGameFaild");
		}

		gameHasEnded = true;
	}
	public void StopSpawner(){
		spawner.enabled = false;
	}
}
