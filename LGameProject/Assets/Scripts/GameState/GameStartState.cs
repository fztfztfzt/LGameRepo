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
