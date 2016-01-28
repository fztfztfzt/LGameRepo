/**
FileName:   PlayerAttackState.cs
Desc: 		主角idle攻击类
Author:		Allen Kashiwa
CreateAt:	2016.01.28
LastEdit:	2016.01.28
**/
using UnityEngine;
using System.Collections;

public class PlayerAttackState : FSMState
{

    public PlayerAttackState(Actor owner, string stateName)
    {
        Owner = owner;
        StateName = stateName;
        Init();
    }

    private Animator mAnimator = null;

    /****************** 基本状态接口 START *****************/
    public override void Init()
    {
        Utils.DBG(StateName + " Init!");
        Player owner = Owner as Player;
        mAnimator = owner.GetComponent<Animator>();
    }

    //进入状态
    public override void Enter(params object[] args)
    {
        Utils.DBG(StateName + " Enter!");
        mAnimator.SetBool("Attack1", true);
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
        if (msg.Equals("On_Anim_End"))
        {
            player.FSM.ExecuteCmd("ACTION_END", args);
        }
    }

    //退出状态
    public override void Exit()
    {
        Utils.DBG(StateName + " Exit!");
        mAnimator.SetBool("Attack1", false);
    }
    /****************** 基本状态接口 END *****************/
}