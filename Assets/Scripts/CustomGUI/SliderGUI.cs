using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public enum HorAndVer_Type
{
    Horizontal, Vertical
}

public class SliderGUI: CustomBaseController
{
    public HorAndVer_Type havType;
    public float minValue;
    public float maxValue;
    public float value;
    public event UnityAction<float> OnValueChanged;

    private float oldValue;
    public GUIStyle thumnStyle;

    public override void OffStyleGui()
    {
        switch (havType)
        {
            case HorAndVer_Type.Horizontal:
                value= GUI.HorizontalSlider(poistion.Pos, value, minValue, maxValue);
                break;
            case HorAndVer_Type.Vertical:
                value = GUI.VerticalSlider(poistion.Pos, value, minValue, maxValue);
                break;
        }
        
        if(oldValue != value)
        {
            OnValueChanged?.Invoke(value);
            oldValue = value;
        }



    }

    public override void OnStyleGui()
    {
        switch (havType)
        {
            case HorAndVer_Type.Horizontal:
                value = GUI.HorizontalSlider(poistion.Pos, value, minValue, maxValue,style, thumnStyle);
                break;
            case HorAndVer_Type.Vertical:
                value = GUI.VerticalSlider(poistion.Pos, value, minValue, maxValue, style, thumnStyle);
                break;
        }
        
        if (oldValue != value)
        {
            OnValueChanged?.Invoke(value);
            oldValue = value;
        }
    }
}
