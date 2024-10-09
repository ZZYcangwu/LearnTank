using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ButtonGUI : CustomBaseController
{
    //提供给外部，用于相应按钮点击事件
    public event UnityAction clickEvent;

    public override void OffStyleGui()
    {
       if( GUI.Button(poistion.Pos, content))
        {
            clickEvent?.Invoke();//可以在此处执行响应事件
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
