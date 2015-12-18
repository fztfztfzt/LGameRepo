﻿/**
FileName:   Main.cs
Desc: 		本项目的主类，这个世界的起源
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2015.11.08
**/
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	//创世之初
	private void Init()
	{
		Utils.SetEnableLog( ConfigManager.Instance.IsEnableLog() );
	}

	public Player PlayerComp = null;

	private void InitPlayer()
	{
		Utils.DBG("InitPlayer Start");
		GameObject playerObj = Instantiate( Resources.Load("Charactors/Prefab/Player") ) as GameObject;
		//playerObj.AddComponent<Player>();
		playerObj.transform.position = Vector3.zero;
		PlayerComp = playerObj.GetComponent<Player>();
	}

	//世界开始醒来
	void Awake()
	{
		Init();
	}

	//世界开始运行
	void Start () {
		Utils.DBG("Hello Miss Orange!");
		Utils.DBG(ConfigManager.Instance.GlobalFilePath);
		InitPlayer();
        Utils.GetMain().GetMainTest();
	}
	
	void Update () {

	}

	//全局事件转发接口，世界通信的渠道
	private void OnMsg()
	{

	}

    public void GetMainTest()
    {
        Utils.DBG("GetMainTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}