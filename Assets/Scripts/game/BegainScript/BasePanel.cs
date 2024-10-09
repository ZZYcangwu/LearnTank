using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 场景基类（单例）
/// </summary>
public class BasePanel<T> : MonoBehaviour where T:class
{
    private static T instanle;//定义声明单例对象

    public static T Instanle => instanle;//创建公共方法访问此对象

    private void Awake()
    {
        instanle = this as T;//初始化对象，因为只会挂载到一个游戏对象中所有可以这样写
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
