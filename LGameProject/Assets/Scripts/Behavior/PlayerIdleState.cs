/**
FileName:   PlayerIdleState.cs
Desc: 		主角idle状态类
Author:		Allen Kashiwa
CreateAt:	2015.11.16
LastEdit:	2016.01.28
**/
using UnityEngine;
using System.Collections;

public class PlayerIdleState : FSMState
{

	public PlayerIdleState(Actor owner, string stateName)
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
		Utils.DBG(StateName + " Enter!");
	}

	//执行状态
    public override void Execute() 
	{
		//Utils.DBG(StateName + " is Updating!!!");
	}

	//给状态发消息
    public override void OnMsg(string msg, params object[] args)
	{
        Player player = Owner as Player;
        //Utils.DBG(StateName + " OnMsg msg is " + msg);
        if (msg.Equals("ON_Z_KEY_DOWN"))
        {
            Utils.ERR(StateName + " OnMsg msg is " + msg);
            player.FSM.ExecuteCmd("ATTACK");
        }
        else if(msg.Equals("ON_MOVE"))
        {
            player.FSM.ExecuteCmd("RUN", args);
        }
	}

	//退出状态
	public override void Exit()
	{
		Utils.DBG(StateName + " Exit!");
	}
	/****************** 基本状态接口 END *****************/
}