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

	private ArrayList mSpritesName = null;
    private SpriteRenderer mSpriteComp = null;
    private ArrayList mSprites = null;

	/****************** 基本状态接口 START *****************/
	public override void Init()
	{
		Utils.DBG(StateName + " Init!");
		mSpritesName = DataManager.Instance.GetPlayerIdleSprites();
		if(mSpritesName == null || mSpritesName.Count == 0)
		{
			Utils.ERR("Init Player Idle sprites failed!");
			return;
        }
        else
        {
            mSprites = new ArrayList();
            for(int i = 0;i < mSpritesName.Count;++i)
            {
                string spriteName = mSpritesName[i] as string;
                Texture2D texture = Resources.Load(string.Format("Charactors/ResReference/{0}", spriteName)) as Texture2D;
                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                mSprites.Add(sprite);
            }
        }
		Player player = Owner as Player;
        mSpriteComp = player.GetComponent<SpriteRenderer>();
        if (mSpriteComp == null)
		{
			Utils.ERR("Init Player Idle get spriteComp failed!");
		}
	}

	//进入状态
	public override void Enter(params object[] args)
	{
		Utils.DBG(StateName + " Enter!");
		mAnimTimer = 0.0f;
	}

    private float mAnimTimer = 0.0f;
    private int mSpriteIndex = 0;
	//执行状态
    public override void Execute() 
	{
		//Utils.DBG(StateName + " is Updating!!!");
        PlayIdleAnim();
	}

    private void PlayIdleAnim()
    {
        if (mSprites == null || mSprites.Count <= 0)
        {
            Utils.ERR(string.Format("There are no anims in {0}", StateName));
        }
        mAnimTimer += Time.deltaTime;
        if (mAnimTimer >= 1.0f)
        {
            // 播放Idle动画
            if (mSpriteIndex >= mSprites.Count)
            {
                mSpriteIndex = 0;
            }
            mSpriteComp.sprite = mSprites[mSpriteIndex] as Sprite;
            ++mSpriteIndex;
            mAnimTimer = 0.0f;
        }
    }

	//给状态发消息
	public override void OnMsg(string msg)
	{
		Utils.DBG(StateName + " OnMsg msg is " + msg);
	}

	//退出状态
	public override void Exit()
	{
		Utils.DBG(StateName + " Exit!");
	}
	/****************** 基本状态接口 END *****************/
}