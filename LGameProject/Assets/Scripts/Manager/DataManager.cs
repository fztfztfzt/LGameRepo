/**
FileName:   DataManager.cs
Desc: 		将各种静态配置存入内存中
Author:		Allen Kashiwa
CreateAt:	2015.11.16
LastEdit:	2015.11.16
**/	
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DataManager {
	/********************** 本类运用单例模式 基本构造START **********************/
	private static DataManager _instance = null;

	public static DataManager Instance {
		get{
			if(_instance == null)
			{
				_instance = new DataManager();
			}
			return _instance;
		}
	}
	private DataManager()
	{
		InitPlayerAnimDic();
	}
	/********************** 基本构造结束 END **********************/

	/********************** 对 Anim.json 文件的管理 START **********************/
	private Dictionary<string,object> mPlayerAnimDic = null;
    private readonly string mPlayerAnimFile = "Config/PlayerData/Anim.json";
	private void InitPlayerAnimDic()
	{
        string conf = Utils.LoadFile(Path.Combine(Application.streamingAssetsPath, mPlayerAnimFile));
        mPlayerAnimDic = MiniJSON.Json.Deserialize(conf) as Dictionary<string,object>;
	}

	public ArrayList GetPlayerIdleSprites()
	{
		List<object> temp = mPlayerAnimDic["Idle"] as List<object>;
		ArrayList result = new ArrayList();
		result.AddRange(temp);
		return result;
	}
	/********************** 对 Anim.json 文件的管理 END **********************/
}