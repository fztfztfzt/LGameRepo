/**
FileName:   Utils.cs
Desc: 		上帝造物需要的一些工具
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2016.01.28
**/
using UnityEngine;
using System.Collections.Generic;
using System.IO;



public static class Utils {
	/********************** Log 的一些接口及属性 **********************/
	private static bool mEnableLog = false;
	
	public static void SetEnableLog(bool flag)
	{
		mEnableLog = flag;
	}
	
	public static void DBG(string msg)
	{
		if(mEnableLog)
		{		
			Debug.Log(msg);
		}
	}
	
	public static void ERR(string msg)
	{
		if(mEnableLog)
		{		
			Debug.LogError(msg);
		}
	}
	
	public static void DBG(Vector3 vec)
	{
		DBG(string.Format("This Vector3 is {0}",vec.ToString()));	
	}
	
	public static void ERR(Vector3 vec)
	{
		ERR(string.Format("This Vector3 is {0}",vec.ToString()));	
	}
	/********************** Log 的一些接口及属性 END **********************/

	/********************** 对文件操作的接口 START **********************/
	public static string LoadFile(string fileFullName)
	{
        string result = string.Empty;
        if ( !File.Exists(fileFullName) )
        {
            ERR(string.Format("{0} is not exists!",fileFullName));
        }else
        {
            return File.ReadAllText(fileFullName);
        }
		return result;
	}
	/********************** 对文件操作的接口 END **********************/

    /********************** 游戏通用功能接口 START **********************/

    /// <summary>
    /// 获取游戏主体
    /// </summary>
    /// <returns></returns>
    public static Main GetMain()
    {
        Main mainComp = null;
        GameObject mainCamera = GameObject.FindGameObjectWithTag("GameMain");
        if (mainCamera == null)
        {
            ERR("There is not a game object whose tag is MainCamera");
        }
        else
        {
            mainComp = mainCamera.GetComponent<Main>();
        }
        return mainComp;
    }

    /// <summary>
    /// 通过文件名读取json文件中的对象
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static Dictionary<string, object> GetJsonDicByFileName(string fileName)
    {
        Dictionary<string, object> mJsonDic = null;
        string text = LoadFile(Path.Combine(Application.streamingAssetsPath, fileName));
        mJsonDic = MiniJSON.Json.Deserialize(text) as Dictionary<string, object>;
        return mJsonDic;
    }
    /********************** 游戏通用功能接口 END **********************/

    /********************** 游戏通用输入操作 START **********************/
    public static InputType GetInputType()
    {
        InputType type = InputType.NONE;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            type = InputType.Z_DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            type = InputType.X_DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            type = InputType.C_DOWN;
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            type = InputType.V_DOWN;
        }
        return type;
    }
    public static float GetMoveInfo()
    {
        float speed = 0.0f;
        speed = Input.GetAxis("Horizontal");
        return speed;
    }
    /********************** 游戏通用输入操作 END **********************/

}