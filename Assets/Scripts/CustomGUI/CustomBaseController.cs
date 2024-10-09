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
    //λ����Ϣ
    public CustomPositionGUI poistion;
    //�ı���Ϣ
    public GUIContent content;
    //�Զ�����ʽ
    public GUIStyle style;
    //�Ƿ����Զ�����ʽ
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
    /// ����һ���ɹ�������д���鷽��
    /// </summary>
    public abstract void OnStyleGui();


    /// <summary>
    /// ����һ���ɹ�������д���鷽��
    /// </summary>
    public abstract void OffStyleGui();

}
