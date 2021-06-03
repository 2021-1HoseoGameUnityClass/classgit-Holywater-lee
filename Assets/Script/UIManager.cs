using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	static UIManager _instance;
	public static UIManager instance { get { return _instance; } }

	[SerializeField] GameObject[] playerHP_obj;

	void Start()
	{
		_instance = this;
	}

	public void PlayerHP()
	{
		int minusHP = 3 - DataManager.instance.playerHP;
		for (int i = 0; i < minusHP; i++)
		{
			playerHP_obj[i].SetActive(false);
		}
	}
}
