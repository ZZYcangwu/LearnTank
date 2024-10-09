using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelGUI : CustomBaseController
{
    public override void OffStyleGui()
    {
        GUI.Label(poistion.Pos, content);
    }

    public override void OnStyleGui()
    {
        GUI.Label(poistion.Pos, content,style);
    }
}
