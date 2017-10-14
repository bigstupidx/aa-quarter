using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {
	
	public LevelData[] allLevelData = new LevelData[100];
	void Start () {
		DontDestroyOnLoad (gameObject);
		//LoadGameData ();
		SceneManager.LoadScene ("Menu");
	}
	public LevelData GetCurrentLevelData(int level){
		return allLevelData [level];
	}
	void OnValidate(){
		allLevelData [0] = new LevelData ();
	}
//	private void LoadGameData(){
//		TextAsset dataAsJson = Resources.Load<TextAsset>("LevelData");
//		GameData loadedData = JsonUtility.FromJson<GameData> (dataAsJson.text);
//		allLevelData = loadedData.allLevelData;
//	}
}
