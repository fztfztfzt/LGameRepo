/**
FileName:   Main.cs
Desc: 		本项目的主类，这个世界的起源
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2015.11.08
**/
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    //创世之初
    private void Init()
    {
        Utils.SetEnableLog(ConfigManager.Instance.IsEnableLog());
    }

    public Player PlayerComp = null;

    private void InitPlayer()
    {
        Utils.DBG("InitPlayer Start");
        GameObject playerObj = Instantiate(Resources.Load("Charactors/Prefab/Player")) as GameObject;
        //playerObj.AddComponent<Player>();
        playerObj.transform.position = Vector3.zero;
        PlayerComp = playerObj.GetComponent<Player>();
    }

    /***************** 游戏主体状态机相关属性及接口 START ****************/
    private FSMState mCurGameState;
    public FSMState CurGameState
    {
        get { return mCurGameState; }
        set { mCurGameState = value; }
    }
    private void CreateGameFSM()
    {
        Utils.DBG("CreateGameFSM");
        GameStartState gameStartState = new GameStartState(this, "GameStartState");
        GamePlayState gamePlayState = new GamePlayState(this, "GameStartState");
        GameEndState gameEndState = new GameEndState(this, "GameStartState");
        gameStartState.AddTransition("START", gamePlayState);
        gamePlayState.AddTransition("END", gameEndState);
        mCurGameState = gameStartState;
    }
    /***************** 游戏主体状态机相关属性及接口 END ****************/

    //世界开始醒来
    void Awake()
    {
        Init();
    }

    //世界开始运行
    void Start()
    {
        //Utils.DBG("Hello Miss Orange!");
        //Utils.DBG(ConfigManager.Instance.GlobalFilePath);
        //InitPlayer();
        //Utils.GetMain().GetMainTest();
        CreateGameFSM();
    }

    void Update()
    {
        if (mCurGameState != null)
        {
            mCurGameState.Execute();
        }
    }

    //全局事件转发接口，世界通信的渠道
    public void OnMsg()
    {

    }

    /// <summary>
    /// 用于判断是否获取游戏主体成功
    /// </summary>
    public void GetMainTest()
    {
        Utils.DBG("GetMainTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}