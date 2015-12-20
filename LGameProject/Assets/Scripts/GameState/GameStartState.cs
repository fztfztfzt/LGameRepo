/**
FileName:   GameStartState.cs
Desc: 		游戏开始状态，显示开始界面
Author:		Allen Kashiwa
CreateAt:	2015.12.20
LastEdit:	2015.12.20
**/
using UnityEngine;
using System.Collections;

public class GameStartState : FSMState
{
    public GameStartState(Object owner, string stateName)
        : base(owner, stateName)
    {
        Init();
    }
    /************************* LOGO界面 START *************************/

    //是否显示游戏启动LOGO
    private bool mIsShowGameLogo = true;
    public bool IsShowGameLogo
    {
        get { return mIsShowGameLogo; }
        set { mIsShowGameLogo = value; }
    }

    private void ShowGameLogo()
    {
        if (mIsShowGameLogo == true)
        {
            //TODO 显示LOGO

            mIsShowGameLogo = false;
            //LOGO显示完毕，显示主菜单
            mIsShowMainMenu = true;
        }
    }
    /************************* LOGO界面 END *************************/
    /************************* 主菜单界面 START *************************/

    private bool mIsShowMainMenu = false;
    public bool IsShowingMainMenu
    {
        get { return mIsShowMainMenu; }
        set { mIsShowMainMenu = value; }
    }

    public void ShowMainMenu()
    {
        if (mIsShowMainMenu == true)
        {
            //TODO 显示主菜单

            mIsShowMainMenu = false;
        }
    }
    /************************* 主菜单界面 START *************************/

    /************************* 状态机部分接口 START *************************/
    public override void Init()
    {
        Utils.DBG(string.Format("{0} Init!", StateName));
    }

    public override void Enter()
    {
        Utils.DBG(string.Format("{0} Enter!", StateName));
    }

    public override void Execute()
    {
        Utils.DBG(string.Format("{0} Execute!", StateName));
        //显示游戏LOGO界面
        ShowGameLogo();
        //显示游戏主菜单
        ShowMainMenu();
    }

    public override void OnMsg(string msg)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
    /************************* 状态机部分接口 END *************************/
}
