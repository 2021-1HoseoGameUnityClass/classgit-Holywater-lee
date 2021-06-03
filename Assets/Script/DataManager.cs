using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 파일 생성용 dll
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
	static DataManager _instance;
	public static DataManager instance { get { return _instance; } }

	public int playerHP = 3;
	public string currecntScene = "Level1";


	void Awake()
	{
		_instance = this;
	}

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		Load();
		playerHP = 3;
	}

	public void Save()
	{
		SaveData saveData = new SaveData();
		saveData.currentScene = currecntScene;
		saveData.playerHp = playerHP;

		FileStream fileStream = File.Create(Application.persistentDataPath + "/save.dat");

		Debug.Log("저장 파일 생성");

		// 2진수로 saveData를 직렬화해서 저장
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, saveData);
		fileStream.Close();
	}
	public void Load()
	{
		// 파일이 있는지 확인
		if (File.Exists(Application.persistentDataPath + "/save.dat"))
		{
			FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

			if (fileStream != null && fileStream.Length > 0)
			{
				// 역직렬화
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
				playerHP = saveData.playerHp;
				UIManager.instance.PlayerHP();
				currecntScene = saveData.currentScene;

				fileStream.Close();
			}
		}
	}
}
