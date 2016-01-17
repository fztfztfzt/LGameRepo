/**
FileName:   PlayerIdleState.cs
Desc: 		主角idle状态类
Author:		Allen Kashiwa
CreateAt:	2015.11.16
LastEdit:	2015.12.28
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

    /****************** 初始化状态动画 START *****************/
    private void InitAnims()
    {
        ArrayList spritesName = DataManager.Instance.GetPlayerIdleSprites();
        if (spritesName == null || spritesName.Count == 0)
        {
            Utils.ERR("Init Player Idle sprites failed!");
            return;
        }
        ArrayList sprites = new ArrayList();
        for (int i = 0; i < spritesName.Count; ++i)
        {
            string spriteName = spritesName[i] as string;
            Texture2D texture = Resources.Load(string.Format("Charactors/ResReference/Anim/{0}", spriteName)) as Texture2D;
            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprites.Add(sprite);
        }
        Player player = Owner as Player;
        AnimComp animComp = player.GetComponent<AnimComp>();
        if (animComp == null)
        {
            Utils.ERR("Init Player Idle get spriteComp failed!");
        }
        else
        {
            animComp.AddAnim("IDLE", sprites);
        }
    }
    /****************** 初始化状态动画 END *****************/

	/****************** 基本状态接口 START *****************/
	public override void Init()
	{
		Utils.DBG(StateName + " Init!");
        InitAnims();
	}

	//进入状态
	public override void Enter(params object[] args)
	{
		Utils.ERR(StateName + " Enter!");
        Player player = Owner as Player;
        AnimComp animComp = player.GetComponent<AnimComp>();
        if (animComp == null)
        {
            Utils.ERR("Player do not have AnimComp!!");
        }
        else
        {
            animComp.PlayAnimByKey("IDLE");
        }
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
		Utils.DBG(StateName + " OnMsg msg is " + msg);
        if (msg.Equals("ON_D_KEY_DOWN"))
        {
            player.FSM.ExecuteCmd("RUN", MoveDir.RIGHT);
        }
        else if (msg.Equals("ON_A_KEY_DOWN"))
        {
            player.FSM.ExecuteCmd("RUN", MoveDir.LEFT);
        }
	}

	//退出状态
	public override void Exit()
	{
		Utils.DBG(StateName + " Exit!");
	}
	/****************** 基本状态接口 END *****************/
}