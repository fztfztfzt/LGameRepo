/**
FileName:   Actor.cs
Desc: 		有限状态机的状态类，这个世界的生物必定处于某种状态之中
Author:		Allen Kashiwa
CreateAt:	2015.10.29
LastEdit:	2015.11.09
**/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class FSMState {

	/***************** 状态类构造 START ****************/
	// 该状态的所有者
	public Actor Owner { get; set; }
	// 该状态的名称
	public string StateName { get; set; }

	//构造函数
	public FSMState()
	{
		
	}

	/***************** 状态类构造 END ****************/

	/****************** 状态关系处理 START *****************/
	//该类的状态跳转
	Dictionary<string, FSMState> Transitions = new Dictionary<string, FSMState>();

	//添加状态跳转命令
	public void AddTransition(string cmd, FSMState state)
	{
		if(Transitions.ContainsKey(cmd) == false)
		{
			Transitions.Add(cmd,state);
		}
		else
		{
			Utils.ERR("You want to add a same key for transition!");

		}

	}

	//获取跳转状态
	public FSMState GetDestState(string cmd)
	{
		if(Transitions.ContainsKey(cmd))
		{
			return Transitions[cmd];
		}
		else
		{
			return null;
		}
	}
	/****************** 状态关系处理 END *****************/

	/****************** 基本状态接口 START *****************/
    public abstract void Init();

	//进入状态
	public abstract void Enter();

	//执行状态
	public abstract void Execute ();

	//给状态发消息
    public abstract void OnMsg(string msg);

	//退出状态
	public abstract void Exit();
	
	/****************** 基本状态接口 END *****************/

}
