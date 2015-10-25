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
using System.IO;

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
		if( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			GlobalFilePath = Application.persistentDataPath;
        }
        else
        {
            GlobalFilePath = Application.dataPath;
        }
	}
	/********************** 初始化项目配置 END **********************/

	/********************** 对conf.json文件的管理 START **********************/
	private Dictionary<string,object> mConfDic = null;
    private readonly string mConfFile = "Config/conf.json";
	private void InitConfDic()
	{
        string conf = Utils.LoadFile(Path.Combine(Application.streamingAssetsPath, mConfFile));
        mConfDic = MiniJSON.Json.Deserialize(conf) as Dictionary<string,object>;
	}

	public bool IsEnableLog()
	{
		return bool.Parse( mConfDic["EnableLog"].ToString() );
	}
	/********************** 对conf.json文件的管理 END **********************/
}