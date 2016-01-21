/**
FileName:   Actor.cs
Desc: 		本项目的角色类，这个世界的生物
Author:		Allen Kashiwa
CreateAt:	2015.10.29
LastEdit:	2016.01.17
**/
using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour{

    /**************** Actor通用属性 START *************/
    private string mActorName = string.Empty;
    public string ActorName
    {
        get { return mActorName; }
        set { mActorName = value; }
    }
    /**************** Actor通用属性 END *************/


	/**************** 状态机管理 START *************/

	//有限状态机
	public FSMSystem FSM = null;

	
	/**************** 状态机管理 END *************/
}
