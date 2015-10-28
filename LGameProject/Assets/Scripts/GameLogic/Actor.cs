/**
FileName:   Actor.cs
Desc: 		本项目的角色类，这个世界的生物
Author:		Allen Kashiwa
CreateAt:	2015.10.29
LastEdit:	2015.10.29
**/
using UnityEngine;
using System.Collections;

public class Actor {

	// Use this for initialization
	void Start () {
		CreateFSM();
	}

	public Actor()
	{
		CreateFSM();
	}
	
	// Update is called once per frame
	public void Update () {
		mFsm.CurrentState.Update();
	}

	/**************** 状态机管理 START *************/

	//有限状态机
	public FSM mFsm = null;

	//创建有限状态机
	private void CreateFSM()
	{
		FSMState firstState = new FSMState();
		mFsm = new FSM(firstState);
	}
	/**************** 状态机管理 END *************/
}
