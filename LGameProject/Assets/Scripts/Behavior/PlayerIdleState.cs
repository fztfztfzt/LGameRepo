/**
FileName:   PlayerIdleState.cs
Desc: 		主角idle状态类
Author:		Allen Kashiwa
CreateAt:	2015.11.16
LastEdit:	2015.11.16
**/
using UnityEngine;
using System.Collections;

public class PlayerIdleState : FSMState
{

	public PlayerIdleState(Actor owner, string stateName)
	{
		Owner = owner;
		StateName = stateName;
		Init();
	}

	private ArrayList mIdleSprites = null;

	private SpriteRenderer spriteComp = null;

	/****************** 基本状态接口 START *****************/
	public void Init()
	{
		Utils.DBG(StateName + " Init!");
		mIdleSprites = DataManager.Instance.GetPlayerIdleSprites();
		if(mIdleSprites == null || mIdleSprites.Count == 0)
		{
			Utils.ERR("Init Player Idle sprites failed!");
			return;
		}
		Player player = Owner as Player;
		spriteComp = player.GetComponent<SpriteRenderer>();
		if(spriteComp == null)
		{
			Utils.ERR("Init Player Idle get spriteComp failed!");
		}
	}

	//进入状态
	public void Enter()
	{
		Utils.DBG(StateName + " Enter!");
		timer = 0.0f;
	}

	private float timer = 0.0f;
	//执行状态
	public void Update () 
	{
		Utils.DBG(StateName + " is Updating!!!");
		timer += Time.deltaTime;
		if(timer >= 1.0f)
		{
			//TODO 播放Idle动画
			//spriteComp.Sprite = ""

		}
	}

	//给状态发消息
	public void OnMsg(string msg)
	{
		Utils.DBG(StateName + " OnMsg msg is " + msg);
	}

	//退出状态
	public void Exit()
	{
		Utils.DBG(StateName + " Exit!");
	}
	/****************** 基本状态接口 END *****************/
}