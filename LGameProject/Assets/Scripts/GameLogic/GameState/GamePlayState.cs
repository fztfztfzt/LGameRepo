/**
FileName:   GamePlayState.cs
Desc: 		游戏操作状态，响应玩家操作
Author:		Allen Kashiwa
CreateAt:	2015.12.20
LastEdit:	2016.01.28
**/
using UnityEngine;
using System.Collections;

public class GamePlayState : FSMState
{
    private Player player = null;
    public GamePlayState(Object owner, string stateName)
        : base(owner, stateName)
    {
        Init();
    }

    public override void Init()
    {
        Utils.DBG(string.Format("{0} Init!", StateName));
        Player mainPlayer = Utils.GetMain().GetMainPlayer();
        if (mainPlayer != null)
        {
            player = mainPlayer;
        }
    }

    public override void Enter(params object[] args)
    {
        Utils.DBG(string.Format("{0} Enter!", StateName));
    }

    public override void Execute()
    {
        //Utils.DBG(string.Format("{0} Execute!", StateName));
        ActionManage();
    }

    private void ActionManage()
    {
        //处理技能按键操纵
        InputType type = Utils.GetInputType();
        if (type == InputType.Z_DOWN)
        {
            player.FSM.CurrentState.OnMsg("ON_Z_KEY_DOWN");
        }
        else if(type == InputType.X_DOWN)
        {
            player.FSM.CurrentState.OnMsg("ON_X_KEY_DOWN");
        }
        else if (type == InputType.C_DOWN)
        {
            player.FSM.CurrentState.OnMsg("ON_C_KEY_DOWN");
        }
        else if (type == InputType.V_DOWN)
        {
            player.FSM.CurrentState.OnMsg("ON_V_KEY_DOWN");
        }
        //移动操作
        float speedFactor = Utils.GetMoveInfo();
        if (speedFactor != 0.0f)
        {
            player.FSM.CurrentState.OnMsg("ON_MOVE", speedFactor);
        }
        else
        {
            player.FSM.CurrentState.OnMsg("ON_STOP_MOVE");
        }
    }

    public override void OnMsg(string msg, params object[] args)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
