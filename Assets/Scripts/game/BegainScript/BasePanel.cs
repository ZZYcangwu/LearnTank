using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �������ࣨ������
/// </summary>
public class BasePanel<T> : MonoBehaviour where T:class
{
    private static T instanle;//����������������

    public static T Instanle => instanle;//���������������ʴ˶���

    private void Awake()
    {
        instanle = this as T;//��ʼ��������Ϊֻ����ص�һ����Ϸ���������п�������д
    }

    public virtual void ShowMe()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        gameObject.SetActive(false);
    }

}
