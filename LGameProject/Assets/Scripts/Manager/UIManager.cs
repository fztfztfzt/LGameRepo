/**
FileName:   UIManager.cs
Desc: 		UI管理器
Author:		Allen Kashiwa
CreateAt:	2016.01.10
LastEdit:	2016.01.10
**/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class UIManager
{
    /********************** 本类运用单例模式 基本构造START **********************/
    private static UIManager _instance = null;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    private UIManager()
    {
        InitUIRoot();
        InitMainMenu();
        LoadDialogUI();
    }

    /********************** 基本构造结束 END **********************/

    /********************** 基本UI节点获取 START **********************/
    private GameObject mUIRootObj = null;

    public GameObject UIRootObj
    {
        get { return mUIRootObj; }
    }
    private void InitUIRoot()
    {
        mUIRootObj = GameObject.FindGameObjectWithTag("UI/UIRoot");
    }

    private GameObject mMainMenuObj = null;
    public GameObject MainMenuObj
    {
        get { return mMainMenuObj; }
    }
    private void InitMainMenu()
    {
        mMainMenuObj = GameObject.FindGameObjectWithTag("UI/MainMenu");
    }

    /********************** 基本UI节点获取 END **********************/

    /********************** 加载对话框UI START **********************/
    private void LoadDialogUI()
    {
        string UIConfFile = "Config/UIData/Dialog.json";
        Dictionary<string, object> dialogUIDic = Utils.GetJsonDicByFileName(UIConfFile);
        string resName = dialogUIDic["res"].ToString();
        Object dialogObj = Resources.Load(resName) as Object;
        GameObject realObj = GameObject.Instantiate(dialogObj) as GameObject;
        realObj.transform.parent = mUIRootObj.transform;
    }
    /********************** 加载对话框UI START **********************/
}