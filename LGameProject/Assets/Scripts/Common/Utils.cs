/**
FileName:   Utils.cs
Desc: 		上帝造物需要的一些工具
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2015.12.18
**/
using UnityEngine;
using System.Collections;
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
    /********************** 游戏通用功能接口 END **********************/

}