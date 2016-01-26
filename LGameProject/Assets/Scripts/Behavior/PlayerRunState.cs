/**
FileName:   PlayerIdleState.cs
Desc: 		主角run状态类，主角的主要移动状态
Author:		Allen Kashiwa
CreateAt:	2015.12.23
LastEdit:	2016.01.27
**/
using UnityEngine;
using System.Collections;

public class PlayerRunState : FSMState
{

    public PlayerRunState(Actor owner, string stateName)
        : base(owner, stateName)
    {
        Init();
    }

    /****************** 状态信息 START *****************/
    private Vector3 mRunDir = Vector3.zero;
    private float mRunSpeed = 2.0f;
    private Vector2 GetRunDirByMoveDir(MoveDir moveDir)
    {
        Vector2 result = Vector2.zero;
        switch (moveDir)
        {
            case MoveDir.LEFT:
                result = Vector2.left;
                break;
            case MoveDir.RIGHT:
                result = Vector2.right;
                break;
        }
        return result;
    }
    private void ChangeRunDirBySpeedFactor(float speedFactor)
    {
        Player player = Owner as Player;
        Vector2 result = Vector2.zero;
        if(speedFactor > 0.0f)
        {
            result = Vector2.right;
        }
        if(speedFactor < 0.0f)
        {
            result = Vector2.left;
        }
        if ((player.FacingRight && result == Vector2.left) || (!player.FacingRight && result == Vector2.right))
        {
            player.Flip();
        }
    }
    /****************** 状态信息 END *****************/


    /****************** 基本状态接口 START *****************/
    public override void Init()
    {
        Utils.DBG(StateName + " Init!");
        Player owner = Owner as Player;
        animator = owner.GetComponent<Animator>();
    }

    private Animator animator = null;

    //进入状态
    public override void Enter(params object[] args)
    {
        Utils.DBG(StateName + " Enter!");
        Player player = Owner as Player;
        //MoveDir dir = (MoveDir)args[0];
        //mRunDir = GetRunDirByMoveDir(dir);
        //if ((player.FacingRight && dir == MoveDir.LEFT) || (!player.FacingRight && dir == MoveDir.RIGHT))
        //{
        //    player.Flip();
        //}
        float speedFactor = float.Parse(args[0].ToString());
        ChangeRunDirBySpeedFactor(speedFactor);
        mRunSpeed = speedFactor * 2.0f;
        mRunDir = Vector2.right;
        animator.SetBool("Run", true);
    }

    //执行状态
    public override void Execute()
    {
        //Utils.DBG(StateName + " is Updating!!!");
        Player player = Owner as Player;
        player.transform.position += mRunDir * mRunSpeed * Time.deltaTime;
    }

    //给状态发消息
    public override void OnMsg(string msg, params object[] args)
    {
        Player player = Owner as Player;
        //Utils.ERR(StateName + " OnMsg msg is " + msg);
        //if (msg.Equals("ON_A_KEY_UP") || msg.Equals("ON_D_KEY_UP"))
        //{
        //    player.FSM.ExecuteCmd("ACTION_END");
        //}
        //else if (msg.Equals("ON_D_KEY_DOWN"))
        //{
        //    player.FSM.ExecuteCmd("RUN", MoveDir.RIGHT);
        //}
        //else if (msg.Equals("ON_A_KEY_DOWN"))
        //{
        //    player.FSM.ExecuteCmd("RUN", MoveDir.LEFT);
        //}
        if (msg.Equals("ON_MOVE"))
        {
            player.FSM.ExecuteCmd("RUN", args);
        }
        else if (msg.Equals("ON_STOP_MOVE"))
        {
            player.FSM.ExecuteCmd("ACTION_END");
        }
    }

    //退出状态
    public override void Exit()
    {
        Utils.ERR(StateName + " Exit!");
        animator.SetBool("Run", false);
    }
    /****************** 基本状态接口 END *****************/
}
