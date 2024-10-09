using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ButtonGUI : CustomBaseController
{
    //�ṩ���ⲿ��������Ӧ��ť����¼�
    public event UnityAction clickEvent;

    public override void OffStyleGui()
    {
       if( GUI.Button(poistion.Pos, content))
        {
            clickEvent?.Invoke();//�����ڴ˴�ִ����Ӧ�¼�
        }

      
    }

    public override void OnStyleGui()
    {
        if (GUI.Button(poistion.Pos, content,style))
        {
            clickEvent?.Invoke();
        }
    }
}
