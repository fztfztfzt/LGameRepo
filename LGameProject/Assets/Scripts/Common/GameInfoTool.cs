/**
FileName:   GameInfoTool.cs
Desc: 		游戏运行信息工具
Author:		Allen Kashiwa
CreateAt:	2015.12.18
LastEdit:	2015.12.18
**/
using UnityEngine;
using System.Collections;


public class GameInfoTool : MonoBehaviour
{
    public bool TurnOn = true;

    /******************* 计算每秒渲染帧数需要的变量 START *******************/
    private float mNowTime = 0.0f;
    private float mLastTime = 0.0f;
    private float mUpdateInterval = 1.0f;
    private int mFrames = 0;
    private int mFPS = 0;
    /******************* 计算每秒渲染帧数需要的变量 END *******************/

    void Start()
    {
        mLastTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        ++mFrames;
        mNowTime = Time.realtimeSinceStartup;
        if (mNowTime >= mLastTime + mUpdateInterval)
        {
            mFPS = (int)(mFrames / (mNowTime - mLastTime));
            mLastTime = mNowTime;
            mFrames = 0;
        }
    }

    void OnGUI()
    {
        if (TurnOn)
        {
            GUI.Box(new Rect(10, 50, 100, 90), "GameInfo Tool");
            GUI.Label(new Rect(25, 75, 90, 50), string.Format("FPS:{0}", mFPS));
        }
    }
}
