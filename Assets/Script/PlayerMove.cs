using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public int moveDir
	{
		get;
		set;
	}
	bool move = false;
	static PlayerMove _instance;
	public static PlayerMove instance { get { return _instance; } }

	void Awake()
	{
		_instance = this;
	}

	private void Update()
	{
		if (move)
		{
			transform.Translate(new Vector3(moveDir, 0, 0));
		}
	}

	public void onMove()
	{
		move = true;
	}

	public void offMove()
	{
		move = false;
	}

}
