/**
FileName:   Actor.cs
Desc: 		有限状态机的状态类，这个世界的生物必定处于某种状态之中
Author:		Allen Kashiwa
CreateAt:	2015.10.29
LastEdit:	2015.10.29
**/
using UnityEngine;
using System.Collections;

public class FSMState {

	public Actor Owner { get; set; }

	//添加状态跳转命令
	public void AddTransition(string cmd, FSMState state)
	{

	}

	//进入状态
	public void Enter()
	{

	}

	//执行状态
	public void Update () 
	{
		Utils.DBG("Update state!!!");
	}

	//给状态发消息
	public void OnMsg()
	{

	}

	//退出状态
	public void Exit()
	{

	}

}
