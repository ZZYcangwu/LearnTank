using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���뷽ʽ
/// </summary>
public enum Alignment_Type
{
    Up,Down, Left, Right,Center,Left_Up,Right_Up,Left_Down,Right_Down   
}

/// <summary>
/// ����Ϊλ�ñ������� ���������λ�� = ��Ļλ��+������ĵ�λ��+ƫ����
/// </summary>
[System.Serializable]//�������л��������ҳ���б༭
public class CustomPositionGUI
{
    //Ҫ���ظ��ⲿ��λ����Ϣ
    private Rect pos = new Rect(0,0,100,50);
    //������ⲿһ��������Ļλ�õı���
    public Alignment_Type screen_Alignment_Position = Alignment_Type.Center;
    //������ⲿһ������������ĵ�ı���
    public Alignment_Type compoment_Center_Alignment_Position = Alignment_Type.Center;
    //������ⲿһ��ƫ����
    public Vector2 padding;

    //���ÿ�
    public float width = 100;
    //���ø�
    public float height = 100;

    private Vector2 comPos;//������ĵ�

    /// <summary>
    /// ����������ĵ�
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

            //�������ĵ�
            CalcCompomentCenterPos();
            //��������λ��
            CalcScreenPosition();
            //���úÿ��
            pos.height = height;
            pos.width = width;
            return pos;        
        }
    }

    /// <summary>
    /// ��������λ��
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
