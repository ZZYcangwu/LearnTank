using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Style_IsOpenOff
{
    Open,Off
}


public abstract class CustomBaseController : MonoBehaviour
{
    //位置信息
    public CustomPositionGUI poistion;
    //文本信息
    public GUIContent content;
    //自定义样式
    public GUIStyle style;
    //是否开启自定义样式
    public Style_IsOpenOff styleStatus = Style_IsOpenOff.Off;

    public void  DrawGUI()
    {
        switch (styleStatus)
        {
            case Style_IsOpenOff.Open:
                OnStyleGui();
                break;
            case Style_IsOpenOff.Off:
                OffStyleGui();
                break;
        }
    }

    /// <summary>
    /// 定义一个可供子类重写的虚方法
    /// </summary>
    public abstract void OnStyleGui();


    /// <summary>
    /// 定义一个可供子类重写的虚方法
    /// </summary>
    public abstract void OffStyleGui();

}
