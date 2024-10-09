using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleGroupGUI : MonoBehaviour
{
    public ToogleGUI[] toogleControllers;

    private ToogleGUI oldToogle;

    private void Start()
    {
        //ѡ��һ���������Ķ�����Ϊfalse
        for (int i = 0; i < toogleControllers.Length; i++)
        {
            ToogleGUI toogle = toogleControllers[i];
            toogle.changeEvent += (e) =>
            {
                if (e)
                {
                    //��������ֵ����Ϊfalse
                    for (int j = 0; j < toogleControllers.Length; j++)
                    {
                        if (toogle != toogleControllers[j])
                        {
                            toogleControllers[j].isSelect = false;
                        }
                    }
                    oldToogle = toogle;
                }
                else { 
                    if(oldToogle == toogle)
                    {
                        toogle.isSelect = true;
                    }
                    
                }
            };

        }
    }

    private void OnGUI()
    {
        
    }
}


