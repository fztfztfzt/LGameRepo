/**
FileName:   Player.cs
Desc: 		本项目的主角类，玩家操控的角色
Author:		Allen Kashiwa
CreateAt:	2015.11.09
LastEdit:	2016.01.28
**/
using UnityEngine;
using System.Collections;

public class Player : Actor{

	void Start () {
		CreateFSM();
	}
	
	void Update () {
		FSM.CurrentState.Execute();
	}

	/**************** 状态机管理 START *************/

	//创建有限状态机
	private void CreateFSM()
	{
        FSMState defaultState = new PlayerDefaultState(this, "PlayerDefaultState");
        FSMState idleState = new PlayerIdleState(this, "PlayerIdleState");
        defaultState.AddTransition("START", idleState);
        FSMState runState = new PlayerRunState(this, "playerRunState");
        PlayerAttackState attackState = new PlayerAttackState(this, "playerAttackState");
        idleState.AddTransition("RUN", runState);
        idleState.AddTransition("ATTACK", attackState);
        runState.AddTransition("RUN", runState);
        runState.AddTransition("ACTION_END", idleState);
        attackState.AddTransition("ACTION_END", idleState);
        FSM = new FSMSystem(defaultState);
	}
	/**************** 状态机管理 END *************/

    /**************** 处理转向 START *************/
    //是否正面向右边
    private bool mFacingRight = true;
    public bool FacingRight
    {
        get { return mFacingRight; }
        set { mFacingRight = value; }
    }
    public void Flip()
    {
        mFacingRight = !mFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    /**************** 处理转向 END *************/
}
