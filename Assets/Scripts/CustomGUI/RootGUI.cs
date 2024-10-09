using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������У����ڱ༭��������
/// ����Ϊ���ڵ��࣬���еĻ���ui���ڴ˽ڵ��л���
/// </summary>
[ExecuteAlways]
public class RootGUI: MonoBehaviour
{
    private CustomBaseController[] customBaseControllers;
    private void Start()
    {
        customBaseControllers = GetComponentsInChildren<CustomBaseController>();//���������Ӷ������
    }

    private void OnGUI()
    {
        customBaseControllers = GetComponentsInChildren<CustomBaseController>();//���������Ӷ������
        foreach (var controller in customBaseControllers)
        {
            controller.DrawGUI();
        }
    }
}
