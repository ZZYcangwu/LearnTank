using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGUI : CustomBaseController
{
    public ScaleMode scaleMode;
    public override void OffStyleGui()
    {
        GUI.DrawTexture(poistion.Pos, content.image, scaleMode);
    }

    public override void OnStyleGui()
    {
        GUI.DrawTexture(poistion.Pos, content.image, scaleMode);

    }

  
}
