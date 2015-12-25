/**
FileName:   GamePlayState.cs
Desc: 		游戏操作状态，响应玩家操作
Author:		Allen Kashiwa
CreateAt:	2015.12.20
LastEdit:	2015.12.20
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
        Player mainPlayer = Utils.GetMain().PlayerComp;
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
        Utils.DBG(string.Format("{0} Execute!", StateName));
        ActionManage();
    }

    private void ActionManage()
    {
        InputType type = Utils.GetInputType();
        if (type == InputType.D_DOWN)
        {
            player.FSM.CurrentState.OnMsg("ON_D_KEY_DOWN");
        }
        else if(type == InputType.A_DOWN)
        {
            player.FSM.CurrentState.OnMsg("ON_A_KEY_DOWN");
        }
        else if (type == InputType.D_UP)
        {
            player.FSM.CurrentState.OnMsg("ON_D_KEY_UP");
        }
        else if (type == InputType.A_UP)
        {
            player.FSM.CurrentState.OnMsg("ON_A_KEY_UP");
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
