/**
FileName:   ActorManager.cs
Desc: 		角色管理器
Author:		Allen Kashiwa
CreateAt:	2016.01.26
LastEdit:	2016.01.26
**/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorManager {
    /********************** 本类运用单例模式 基本构造START **********************/
    private static ActorManager _instance = null;

    public static ActorManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ActorManager();
            }
            return _instance;
        }
    }
    private ActorManager()
    {

    }
    /********************** 基本构造结束 END **********************/
    /********************** 角色管理 START **********************/
    //存入主角的容器
    private ArrayList mActors = null;
    public void AddActor(Actor actor)
    {
        if(mActors == null)
        {
            mActors = new ArrayList();
        }
        if (mActors.Contains(actor))
        {
            Utils.ERR("ActorManager AddActor you already add the player: " + actor.ActorName);
            return;
        }
        else
        {
            mActors.Add(actor);
        }
    }

    public void RemoveActor(Actor actor)
    {
        mActors.Remove(actor);
    }

    public void RemoveActorByName(string name)
    {
        ArrayList temp = new ArrayList();
        foreach (Actor item in mActors)
        {
            if(!item.ActorName.Equals(name))
            {
                temp.Add(item);
            }
        }
        mActors = temp;
    }

    public Actor GetActorByName(string name)
    {
        Actor result = null;
        foreach (Actor item in mActors)
        {
            if (item.ActorName.Equals(name))
            {
                result = item;
            }
        }
        return result;
    }
    /********************** 角色管理 END **********************/

}
