/**
FileName:   AnimEvent.cs
Desc: 		动画事件类
Author:		Allen Kashiwa
CreateAt:	2016.01.28
LastEdit:	2016.01.28
**/
using UnityEngine;
using System.Collections;

public class AnimEvent : MonoBehaviour {

    private Actor actor = null;
    void Awake()
    {
        actor = GetComponent<Actor>();
    }

    public void OnAnimEnd()
    {
        actor.FSM.CurrentState.OnMsg("On_Anim_End");
    }
}
