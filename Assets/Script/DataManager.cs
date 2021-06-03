using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ dll
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

		Debug.Log("���� ���� ����");

		// 2������ saveData�� ����ȭ�ؼ� ����
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, saveData);
		fileStream.Close();
	}
	public void Load()
	{
		// ������ �ִ��� Ȯ��
		if (File.Exists(Application.persistentDataPath + "/save.dat"))
		{
			FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

			if (fileStream != null && fileStream.Length > 0)
			{
				// ������ȭ
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
