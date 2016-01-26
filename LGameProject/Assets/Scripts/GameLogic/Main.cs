/**
FileName:   Main.cs
Desc: 		本项目的主类，这个世界的起源
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2016.01.26
**/
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    //创世之初
    private void Init()
    {
        Utils.SetEnableLog(ConfigManager.Instance.IsEnableLog());
        InitPlayer();
        InitManagers();
    }

    //玩家操纵的主角，玩家同一时间只能操纵一个主角，主角可能更换
    private Player mMainPlayer = null;

    /// <summary>
    /// 改变操纵角色
    /// </summary>
    /// <param name="player"></param>
    public void ChangeMainPlayer(Player player)
    {
        if(player == null)
        {
            Utils.ERR("Main ChangeMainPlayer the player you want to change is null");
        }
        mMainPlayer = player;
    }

    public Player GetMainPlayer()
    {
        if (mMainPlayer == null)
        {
            Utils.ERR("Main GetMainPlayer main player is null. You maybe have not init one");
            return null;
        }
        return mMainPlayer;
    }

    private void InitPlayer()
    {
        Utils.DBG("InitPlayer Start");
        GameObject playerObj = Instantiate(Resources.Load("Charactors/Prefab/ChuYunGe")) as GameObject;
        playerObj.transform.position = Vector3.zero;
        Player playerComp = playerObj.GetComponent<Player>();
        playerComp.ActorName = "楚云歌";
        ActorManager.Instance.AddActor(playerComp);
        //默认主角
        ChangeMainPlayer(playerComp);
    }

    private void InitManagers()
    {
        UIManager UIMgr = UIManager.Instance;
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
        mCurGameState = gamePlayState;
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