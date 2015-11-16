/**
FileName:   Player.cs
Desc: 		本项目的主角类，玩家操控的角色
Author:		Allen Kashiwa
CreateAt:	2015.11.09
LastEdit:	2015.11.09
**/
using UnityEngine;
using System.Collections;

public class Player : Actor{

	void Start () {
		CreateFSM();
	}
	
	void Update () {
		FSM.CurrentState.Update();
	}

	/**************** 状态机管理 START *************/

	//创建有限状态机
	private void CreateFSM()
	{
		FSMState idleState = new PlayerIdleState(this, "playerIdleState");
		FSMState walkState = new FSMState(this, "playerWalkState");
		FSMState runState = new FSMState(this, "playerRunState");
		idleState.AddTransition("WALK",walkState);
		idleState.AddTransition("RUN",runState);
		FSM = new FSMSystem(idleState);
	}
	/**************** 状态机管理 END *************/
}
