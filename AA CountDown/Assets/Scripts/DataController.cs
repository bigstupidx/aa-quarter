using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {
	
	private LevelData[] allLevelData;
	void Start () {
		DontDestroyOnLoad (gameObject);
		LoadGameData ();
		SceneManager.LoadScene ("Menu");
	}
	public LevelData GetCurrentLevelData(int level){
		return allLevelData [level-1];
	}
	private void LoadGameData(){
		TextAsset dataAsJson = Resources.Load<TextAsset>("LevelData");
		GameData loadedData = JsonUtility.FromJson<GameData> (dataAsJson.text);
		allLevelData = loadedData.allLevelData;
	}
}
