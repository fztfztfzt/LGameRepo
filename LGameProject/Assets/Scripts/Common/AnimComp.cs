/**
FileName:   AnimComp.cs
Desc: 		用于2D对象的动画组件
Author:		Allen Kashiwa
CreateAt:	2015.12.27
LastEdit:	2015.12.27
**/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimComp : MonoBehaviour
{
    //帧渲染器
    private SpriteRenderer mSpriteRenderer = null;
    //按键值存储动画帧
    private Dictionary<string, ArrayList> mAnims = null;
    //当前正在播放的动画键
    private string mCurAnimKey = string.Empty;
    public string CurAnimKey
    {
        get { return mCurAnimKey; }
        set { mCurAnimKey = value; }
    }
    //当前正在播放的动画帧组
    private ArrayList mCurAnims = null;
    //当前播放帧
    private int mCurSpriteIndex = 0;
    //播放速度
    private float mPlaySpeed = 1.0f;
    //更换帧频率
    private float mChangeSpriteInterval
    {
        get
        {

            return 1.0f / mPlaySpeed;
        }
    }
    //动画计时器
    private float mAnimTimer = 0.0f;
    //正在播放动画标志
    private bool mPlayingAnim = false;

    /// <summary>
    /// 添加动画
    /// </summary>
    /// <param name="key">动画帧组名</param>
    /// <param name="sprites">动画帧对象</param>
    public void AddAnim(string key, ArrayList sprites)
    {
        if (sprites == null)
        {
            Utils.ERR("The anims you want to add is null");
        }
        if (mAnims == null)
        {
            mAnims = new Dictionary<string, ArrayList>();
        }
        if (!mAnims.ContainsKey(key))
        {
            mAnims.Add(key, sprites);
        }
        else
        {
            Utils.ERR(string.Format("You already add the anims for {0}", key));
        }
    }

    /// <summary>
    /// 设置动画
    /// </summary>
    /// <param name="key">动画帧组名</param>
    /// <param name="sprites">动画帧对象</param>
    public void SetAnim(string key, ArrayList sprites)
    {
        if (mAnims == null || !mAnims.ContainsKey(key))
        {
            Utils.ERR("mAnims is null");
        }
        if (!mAnims.ContainsKey(key))
        {
            Utils.ERR(string.Format("mAnims do not have the key: {0}", key));
        }
        else
        {
            mAnims[key] = sprites;
        }
    }

    /// <summary>
    /// 通过动画键值来播放动画
    /// </summary>
    /// <param name="key"></param>
    public void PlayAnimByKey(string key)
    {
        if (mAnims == null || !mAnims.ContainsKey(key))
        {
            Utils.ERR(string.Format("You can not play the anim which key is {0} or the mAnim is null", key));
            return;
        }
        if (mSpriteRenderer == null)
        {
            mSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        mCurAnimKey = key;
        mCurAnims = mAnims[key];
        mPlayingAnim = true;
    }

    public void StopAnim()
    {
        mPlayingAnim = false;
    }

    public void SetPlaySpeed(float speed)
    {
        //避免除0错误
        if (speed == 0.0f)
        {
            Utils.ERR("The play speed should not be 0. If you want to stop the anim you should use StopAnim function!");
            speed = 1.0f;
        }
        mPlaySpeed = speed;
    }

    /// <summary>
    /// 真正只需播放动画的操作，每帧调用
    /// </summary>
    private void DoPlayAnims()
    {
        mAnimTimer += Time.deltaTime;
        if (mAnimTimer >= mChangeSpriteInterval)
        {
            if (mCurSpriteIndex == mCurAnims.Count)
            {
                mCurSpriteIndex = 0;
            }
            mSpriteRenderer.sprite = mCurAnims[mCurSpriteIndex] as Sprite;
            ++mCurSpriteIndex;
            mAnimTimer = 0.0f;
        }
    }

    void Update()
    {
        if (mPlayingAnim == false)
        {
            return;
        }
        DoPlayAnims();
    }
}