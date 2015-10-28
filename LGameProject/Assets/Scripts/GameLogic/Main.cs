/**
FileName:   Main.cs
Desc: 		本项目的主类，这个世界的起源
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2015.10.16
**/
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	//创世之初
	private void Init()
	{
		Utils.SetEnableLog( ConfigManager.Instance.IsEnableLog() );
	}

	public Actor Player = null;

	private void InitPlayer()
	{
		Player = new Actor();
	}

	//世界开始醒来
	void Awake()
	{
		Init();
	}

	// Use this for initialization
	void Start () {
		Utils.DBG("Hello Miss Orange!");
		Utils.DBG(ConfigManager.Instance.GlobalFilePath);
		InitPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		Player.Update();
	}
	
}