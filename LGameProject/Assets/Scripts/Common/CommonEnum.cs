/**
FileName:   CommonEnum.cs
Desc: 		公共枚举类型
Author:		Allen Kashiwa
CreateAt:	2015.10.16
LastEdit:	2016.01.28
**/
using System;
using System.Collections.Generic;

public enum InputType
{
    NONE = 0,
    Z_DOWN,
    X_DOWN,
    C_DOWN,
    V_DOWN,
    L_BTN_DOWN,
    L_BTN_UP
}

public enum MoveDir
{
    UP = 0,
    DOWN,
    LEFT,
    RIGHT
}