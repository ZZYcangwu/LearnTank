using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public ButtonGUI btnQuit;
    public ButtonGUI btnSub;
    public ButtonGUI btnCancel;


    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            HideMe();
        };

        btnSub.clickEvent += () =>
        {
            //�˳�����ҳ��
            SceneManager.LoadScene("BeginGame");
        };

        btnCancel.clickEvent += () =>
        {
            HideMe();
        };

        HideMe();
    }

   
}
