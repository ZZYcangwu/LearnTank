using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToogleGUI : CustomBaseController
{
    public bool isSelect;
    public event UnityAction<bool> changeEvent;
    private bool oldSelect;
    public override void OffStyleGui()
    {
        isSelect = GUI.Toggle(poistion.Pos, isSelect, content);
        if(oldSelect != isSelect)
        {
            changeEvent?.Invoke(isSelect);

            oldSelect = isSelect;
        }
    }

    public override void OnStyleGui()
    {
        isSelect = GUI.Toggle(poistion.Pos, isSelect, content,style);
        if (oldSelect != isSelect)
        {
            changeEvent?.Invoke(isSelect);

            oldSelect = isSelect;
        }
    }
}
