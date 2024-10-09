using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 对齐方式
/// </summary>
public enum Alignment_Type
{
    Up,Down, Left, Right,Center,Left_Up,Right_Up,Left_Down,Right_Down   
}

/// <summary>
/// 此类为位置变量基类 组件真正的位置 = 屏幕位置+组件中心点位置+偏移量
/// </summary>
[System.Serializable]//必须序列化后才能在页面中编辑
public class CustomPositionGUI
{
    //要返回给外部的位置信息
    private Rect pos = new Rect(0,0,100,50);
    //定义给外部一个调节屏幕位置的变量
    public Alignment_Type screen_Alignment_Position = Alignment_Type.Center;
    //定义给外部一个调节组件中心点的变量
    public Alignment_Type compoment_Center_Alignment_Position = Alignment_Type.Center;
    //定义给外部一个偏移量
    public Vector2 padding;

    //设置宽
    public float width = 100;
    //设置高
    public float height = 100;

    private Vector2 comPos;//组件中心点

    /// <summary>
    /// 计算组件中心点
    /// </summary>
    private void CalcCompomentCenterPos()
    {
        switch(compoment_Center_Alignment_Position)
        {
            case Alignment_Type.Up:
                comPos.x = -width / 2;
                comPos.y = 0;
                break;
            case Alignment_Type.Down:
                comPos.x = -width/2;
                comPos.y = -height;
                break;
            case Alignment_Type.Left:
                comPos.x = 0;
                comPos.y = -height/2;
                break;
            case Alignment_Type.Right:
                comPos.x = -width;
                comPos.y = -height / 2;
                break;
            case Alignment_Type.Center:
                comPos.x = -width / 2;
                comPos.y = -height/2;
                break;
            case Alignment_Type.Left_Up:
                comPos.x = 0;
                comPos.y = 0;
                break;
            case Alignment_Type.Right_Up:
                comPos.x = -width;
                comPos.y = 0;
                break;
            case Alignment_Type.Left_Down:
                comPos.x = 0;
                comPos.y = -height;
                break;
            case Alignment_Type.Right_Down:
                comPos.x = -width;
                comPos.y = -height;
                break;
        }
    }

    public Rect Pos
    {
        get {

            //计算中心点
            CalcCompomentCenterPos();
            //计算最终位置
            CalcScreenPosition();
            //设置好宽高
            pos.height = height;
            pos.width = width;
            return pos;        
        }
    }

    /// <summary>
    /// 计算最终位置
    /// </summary>
    private void CalcScreenPosition()
    {
        switch(screen_Alignment_Position)
        {
            case Alignment_Type.Up:
                pos.x = Screen.width / 2 + comPos.x+padding.x;
                pos.y = 0 + comPos.y + padding.y;
                break;
            case Alignment_Type.Down:
                pos.x = Screen.width / 2 + comPos.x + padding.x;
                pos.y = Screen.height + comPos.y - padding.y;
                break;
            case Alignment_Type.Left:
                pos.x = 0 + comPos.x + padding.x;
                pos.y = Screen.height/2 + comPos.y + padding.y;
                break;
            case Alignment_Type.Right:
                pos.x = Screen.width + comPos.x - padding.x;
                pos.y = Screen.height / 2 + comPos.y + padding.y;
                break;
            case Alignment_Type.Center:
                pos.x = Screen.width/2 + comPos.x + padding.x;
                pos.y = Screen.height / 2 + comPos.y + padding.y;
                break;
            case Alignment_Type.Left_Up:
                pos.x = 0 + comPos.x + padding.x;
                pos.y = 0 + comPos.y + padding.y;
                break;
            case Alignment_Type.Right_Up:
                pos.x = Screen.width + comPos.x - padding.x;
                pos.y = 0 + comPos.y + padding.y;
                break;
            case Alignment_Type.Left_Down:
                pos.x = 0 + comPos.x + padding.x;
                pos.y = Screen.height + comPos.y - padding.y;
                break;
            case Alignment_Type.Right_Down:
                pos.x = Screen.width + comPos.x - padding.x;
                pos.y = Screen.height + comPos.y - padding.y;
                break;
        }
    }
}
