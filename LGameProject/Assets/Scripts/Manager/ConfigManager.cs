/**
FileName:   ConfigManager.cs
Desc: 		创世之初，遵循的法度
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2015.10.16
**/	
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfigManager {
	/********************** 本类运用单例模式 基本构造START **********************/
	private static ConfigManager _instance = null;

	public static ConfigManager Instance {
		get{
			if(_instance == null)
			{
				_instance = new ConfigManager();
			}
			return _instance;
		}
	}
	private ConfigManager()
	{
		InitBasicConfig();
		InitConfDic();
	}
	/********************** 基本构造结束 END **********************/

	/********************** 初始化项目配置 START **********************/
	public string GlobalFilePath = string.Empty;

	private void InitBasicConfig()
	{
		GlobalFilePath = "test";
		if( Application.platform == RuntimePlatform.Android )
		{
			GlobalFilePath = Application.persistentDataPath;
		}else if( Application.platform == RuntimePlatform.WindowsPlayer )
		{
			GlobalFilePath = Application.dataPath;
		}
	}
	/********************** 初始化项目配置 END **********************/

	/********************** 对conf.json文件的管理 START **********************/
	private Dictionary<string,object> mConfDic = null;

	private void InitConfDic()
	{
		mConfDic = new Dictionary<string,object>();
		mConfDic.Add("EnableLog",true);
	}

	public bool IsEnableLog()
	{
		return bool.Parse( mConfDic["EnableLog"].ToString() );
	}
	/********************** 对conf.json文件的管理 END **********************/
}