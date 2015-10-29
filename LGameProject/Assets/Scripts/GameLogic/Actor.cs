/**
FileName:   Actor.cs
Desc: 		本项目的角色类，这个世界的生物
Author:		Allen Kashiwa
CreateAt:	2015.10.29
LastEdit:	2015.10.29
**/
using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour{

	// Use this for initialization
	void Start () {
		CreateFSM();
	}

	public Actor()
	{
		CreateFSM();
	}
	
	// Update is called once per frame
	void Update () {
		FSM.CurrentState.Update();
	}

	/**************** 状态机管理 START *************/

	//有限状态机
	public FSMSystem FSM = null;

	//创建有限状态机
	private void CreateFSM()
	{
		FSMState firstState = new FSMState();
		FSM = new FSMSystem(firstState);
	}
	/**************** 状态机管理 END *************/
}
