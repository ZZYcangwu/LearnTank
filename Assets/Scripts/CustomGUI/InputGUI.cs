using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputGUI: CustomBaseController
{
    public bool isPass;
    public event UnityAction<string> valueChangeEvent;
    public string oldValue;

    public override void OffStyleGui()
    {
        if(isPass)
        {
            content.text = GUI.PasswordField(poistion.Pos, content.text, '*');

        }
        else
        {
            content.text = GUI.TextField(poistion.Pos, content.text);
        }
        oldValue = content.text;
        if(oldValue != content.text) { 
            valueChangeEvent?.Invoke(content.text);
        }
    }

    public override void OnStyleGui()
    {
        if (isPass)
        {
            content.text = GUI.PasswordField(poistion.Pos, content.text, '*',style);
        }
        else
        {
            content.text = GUI.TextField(poistion.Pos, content.text,style);
        }
        oldValue = content.text;
        if (oldValue != content.text)
        {
            valueChangeEvent?.Invoke(content.text);
        }
    }

}
