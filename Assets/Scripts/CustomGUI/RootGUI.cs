using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 总是运行，能在编辑器中运行
/// 此类为根节点类，所有的绘制ui都在此节点中绘制
/// </summary>
[ExecuteAlways]
public class RootGUI: MonoBehaviour
{
    private CustomBaseController[] customBaseControllers;
    private void Start()
    {
        customBaseControllers = GetComponentsInChildren<CustomBaseController>();//查找所有子对象的类
    }

    private void OnGUI()
    {
        customBaseControllers = GetComponentsInChildren<CustomBaseController>();//查找所有子对象的类
        foreach (var controller in customBaseControllers)
        {
            controller.DrawGUI();
        }
    }
}
