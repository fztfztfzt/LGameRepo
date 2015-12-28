/**
FileName:   PlayerDefaultState.cs
Desc: 		主角初始化默认状态类
Author:		Allen Kashiwa
CreateAt:	2015.12.28
LastEdit:	2015.12.28
**/
using UnityEngine;
using System.Collections;

public class PlayerDefaultState : FSMState
{

    public PlayerDefaultState(Actor owner, string stateName)
    {
        Owner = owner;
        StateName = stateName;
        Init();
    }

    /****************** 基本状态接口 START *****************/
    public override void Init()
    {
        Utils.DBG(StateName + " Init!");
    }

    //进入状态
    public override void Enter(params object[] args)
    {
        Utils.ERR(StateName + " Enter!");
    }

    //执行状态
    public override void Execute()
    {
        //Utils.DBG(StateName + " is Updating!!!");
        Player player = Owner as Player;
        player.FSM.ExecuteCmd("START");
    }

    //给状态发消息
    public override void OnMsg(string msg, params object[] args)
    {
    }

    //退出状态
    public override void Exit()
    {
        Utils.DBG(StateName + " Exit!");
    }
    /****************** 基本状态接口 END *****************/
}