using System.Collections;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class PlayerPrefsUtil 
{
    private static PlayerPrefsUtil instance = new PlayerPrefsUtil();//����һ��˽�б���

    public static PlayerPrefsUtil Instance
    {

        get { return instance; } 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj">Ҫ�洢�����ݶ���</param>
    /// <param name="keyName">�洢������</param>
    public void SaveData(object obj,string keyName)
    { 
        Type type = obj.GetType();
        FieldInfo[] fieldInfos = type.GetFields();//��ȡ�����ֶ�
        string keyValueName = "";
        foreach(FieldInfo fieldInfo in fieldInfos)
        {
            Debug.Log(fieldInfo.Name);
            //������������
            keyValueName = keyName + "_" +type.Name+"_"+fieldInfo.FieldType.Name+"_"+fieldInfo.Name;
            SaveParam(fieldInfo.GetValue(obj), keyValueName);
        }
        PlayerPrefs.Save();

    }
    /// <summary>
    /// �洢����ֵ
    /// </summary>
    /// <param name="param"></param>
    /// <param name="keyName"></param>
    private void SaveParam(object param,string keyName)
    {
        Debug.Log(keyName);
        if(param == null)
        {
            return;
        }

        if (param.GetType() == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)param);
        }
        else if (param.GetType() == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)param);
        }
        else if (param.GetType() == typeof(string))
        {
            PlayerPrefs.SetString(keyName, (string)param);
        }
        else if (param.GetType() == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)param ? 1 : 0);
        }
        else if (typeof(IList).IsAssignableFrom(param.GetType()))
        {
            IList list = (IList)param;
            //�洢����
            PlayerPrefs.SetInt(keyName+"_list_"+"count", list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                SaveParam(list[i], keyName + "_" + i);
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(param.GetType()))
        {
            IDictionary dict = (IDictionary)param;
            ICollection keys = dict.Keys;
            //�洢����
            PlayerPrefs.SetInt(keyName + "_dic_" + "count", dict.Count);
            int index = 0;
            foreach (object key in keys)
            {
                SaveParam(key, keyName + "_dic_key_" + index);
                SaveParam(dict[key], keyName + "_dic_value" + index);
                index++;

            }
        }
        else
        {
            SaveData(param, keyName);
        }
    }



    /// <summary>
    /// ȡֵ
    /// </summary>
    /// <param name="type"></param>
    /// <param name="keyName"></param>
    /// <returns></returns>
    public object LoadData(Type type, string keyName)
    {
        object obj = Activator.CreateInstance(type);
        //��ȡ�����ֶ�
        FieldInfo[] fieldInfos = type.GetFields();
        string keyLoadName = "";
        foreach(FieldInfo fieldInfo in fieldInfos)
        {
            //�������������
            keyLoadName = keyName + "_"+type.Name+"_"+fieldInfo.FieldType.Name+"_"+fieldInfo.Name;
            Debug.Log(fieldInfo);
            fieldInfo.SetValue(obj, LoadParam(fieldInfo.FieldType,keyLoadName));
            //LoadParam(fieldInfo, keyLoadName);
        }


        return obj;
    }

    private object LoadParam(Type fieldType, string keyName)
    {
        Debug.Log(fieldType);


        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list = Activator.CreateInstance(fieldType) as IList;
            //��ȡ����
            int count = PlayerPrefs.GetInt(keyName + "_list_" + "count");
            for (int i = 0; i < count; i++)
            {
                //�˴���ȡ�䷺�͵�����
                list.Add(LoadParam(fieldType.GetGenericArguments()[0], keyName + "_" + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;
            //��ȡ����
            int count = PlayerPrefs.GetInt(keyName + "_dic_" + "count");
            for (int i = 0; i < count; i++)
            {
                dic.Add(LoadParam(fieldType.GetGenericArguments()[0], keyName + "_dic_key_" + i),
                    LoadParam(fieldType.GetGenericArguments()[1], keyName + "_dic_value" + i));
            }
            return dic;
        }
        else
        {
            return LoadData(fieldType, keyName);
        }
    }
}
