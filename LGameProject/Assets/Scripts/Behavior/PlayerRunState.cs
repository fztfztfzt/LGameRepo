/**
FileName:   PlayerIdleState.cs
Desc: 		主角run状态类，主角的主要移动状态
Author:		Allen Kashiwa
CreateAt:	2015.12.23
LastEdit:	2015.12.23
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

    /****************** 动画相关 START *****************/
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
            Texture2D texture = Resources.Load(string.Format("Charactors/ResReference/{0}", spriteName)) as Texture2D;
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
            animComp.AddAnim("RUN", sprites);
        }
    }
    /****************** 动画相关END *****************/

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
    /****************** 状态信息 END *****************/


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
        MoveDir dir = (MoveDir)args[0];
        Vector3 temp = GetRunDirByMoveDir(dir);
        if (temp != mRunDir)
        {
            player.Flip();
        }
        mRunDir = temp;
        AnimComp animComp = player.GetComponent<AnimComp>();
        if (animComp == null)
        {
            Utils.ERR("Player do not have AnimComp!");
        }
        else
        {
            animComp.PlayAnimByKey("RUN");
        }
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
        Utils.ERR(StateName + " OnMsg msg is " + msg);
        if (msg.Equals("ON_A_KEY_UP") || msg.Equals("ON_D_KEY_UP"))
        {
            player.FSM.ExecuteCmd("ACTION_END");
        }
    }

    //退出状态
    public override void Exit()
    {
        Utils.DBG(StateName + " Exit!");
    }
    /****************** 基本状态接口 END *****************/
}
