/**
FileName:   DataManager.cs
Desc: 		将各种静态配置存入内存中
Author:		Allen Kashiwa
CreateAt:	2015.11.16
LastEdit:	2016.01.10
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
        InitUITextDic();
	}
	/********************** 基本构造结束 END **********************/

    /********************** 对 PlayerData/Anim.json 文件的管理 START **********************/
	private Dictionary<string,object> mPlayerAnimDic = null;
    private readonly string mPlayerAnimFile = "Config/ActorData/ChuYunGe/Anim.json";
	private void InitPlayerAnimDic()
	{
        string conf = Utils.LoadFile(Path.Combine(Application.streamingAssetsPath, mPlayerAnimFile));
        if (string.IsNullOrEmpty(conf))
        {
            Utils.ERR(string.Format("InitPlayerAnimDic failed"));
            return;
        }
        mPlayerAnimDic = MiniJSON.Json.Deserialize(conf) as Dictionary<string,object>;
	}

	public ArrayList GetPlayerIdleSprites()
	{
		List<object> temp = mPlayerAnimDic["Idle"] as List<object>;
		ArrayList result = new ArrayList();
		result.AddRange(temp);
		return result;
	}
    /********************** 对 PlayerData/Anim.json 文件的管理 END **********************/

    /********************** 对 TextData/UIText.json 文件的管理 START **********************/
    private Dictionary<string, object> mUITextDic = null;
    private readonly string mUITextFile = "Config/TextData/UIText.json";
    private void InitUITextDic()
    {
        string conf = Utils.LoadFile(Path.Combine(Application.streamingAssetsPath, mUITextFile));
        if (string.IsNullOrEmpty(conf))
        {
            Utils.ERR(string.Format("InitUITextDic failed"));
            return;
        }
        mUITextDic = MiniJSON.Json.Deserialize(conf) as Dictionary<string, object>;
    }

    public string GetUITextByKey(string key)
    {
        string result = string.Empty;
        if (mUITextDic == null)
        {
            Utils.ERR(string.Format("mUITextDic is null"));
        }
        else if (!mUITextDic.ContainsKey(key))
        {
            Utils.ERR(string.Format("mUITextDic do not contains key {0}",key));
        }
        else
        {
            result = mUITextDic[key].ToString();
        }
        return result;
    }
    /********************** 对 PlayerData/Anim.json 文件的管理 END **********************/
}