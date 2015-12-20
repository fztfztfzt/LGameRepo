/**
FileName:   GamePlayState.cs
Desc: 		游戏结束状态，显示结束界面
Author:		Allen Kashiwa
CreateAt:	2015.12.20
LastEdit:	2015.12.20
**/
using UnityEngine;
using System.Collections;

public class GameEndState : FSMState
{

    public GameEndState(Object owner, string stateName)
        : base(owner, stateName)
    {
        Init();
    }

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
    }

    public override void OnMsg(string msg)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
