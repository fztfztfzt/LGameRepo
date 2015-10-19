/**
FileName:   Utils.cs
Desc: 		上帝造物需要的一些工具
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2015.10.17
**/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		return string.Empty;
	}
	/********************** 对文件操作的接口 END **********************/
}