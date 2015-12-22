/**
FileName:   Actor.cs
Desc: 		有限状态机类，这个世界的生物必定有一个状态机来管理自己的状态
Author:		Allen Kashiwa
CreateAt:	2015.10.29
LastEdit:	2015.10.29
**/
using UnityEngine;
using System.Collections;

public class FSMSystem {

	public FSMState CurrentState { get; set; }

	//状态链表
	public ArrayList States = new ArrayList();

	public FSMSystem(FSMState curState) {
		Utils.DBG("FSMSystem Start");
		CurrentState = curState;
	}

	public void ExecuteCmd(string cmd, params object[] args)
	{
		FSMState toState = CurrentState.GetDestState(cmd);
		if(toState == null)
		{
			return;
		}
		else
		{
			CurrentState.Exit();
			CurrentState = toState;
            CurrentState.Enter(args);
		}
	}

}
