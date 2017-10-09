using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {

	private LevelData[] allLevelData;
	private string gameDataFileName = "LevelData.json";
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		LoadGameData ();
		SceneManager.LoadScene ("Menu");
	}
	public LevelData GetCurrentLevelData(int level){
		return allLevelData [level-1];
	}
	// Update is called once per frame
	void Update () {
		
	}
	private void LoadGameData(){
//		string filePath = Application.persistentDataPath + "/Resources/LevelData.json";
//		Debug.Log (filePath);
//		if (File.Exists (filePath)) {
//			string dataAsJson = File.ReadAllText (filePath);
//			Debug.Log (dataAsJson);
//			GameData loadedData = JsonUtility.FromJson<GameData> (dataAsJson);
//
//			allLevelData = loadedData.allLevelData;
//		} else {
//			Debug.LogError ("cannot load game data");
//		}
		TextAsset dataAsJson = Resources.Load<TextAsset>("LevelData");
		GameData loadedData = JsonUtility.FromJson<GameData> (dataAsJson.text);
		allLevelData = loadedData.allLevelData;
	}
}
