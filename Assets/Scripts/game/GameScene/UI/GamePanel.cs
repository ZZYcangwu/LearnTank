using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : BasePanel<GamePanel>
{
    public LabelGUI labScore;
    public LabelGUI labTime;
    public ButtonGUI btnSetting;
    public ButtonGUI btnQuit;

    public TextureGUI texBlood;

    public int nowScore = 0;//��ǰ����
    public float maxWidth;//Ѫ�������
    public float nowTime;
    void Start()
    {
        //������ť�¼�
        //�������ð�ť
        btnSetting.clickEvent += ()=>{
            SettingPanel.Instanle.ShowMe();
        };
        //�����˳���ť
        btnQuit.clickEvent += () => {
            //����ʾ��
            QuitPanel.Instanle.ShowMe();
        };
        UpdateBlood(10,100);
        UpdateScore(100);
    }


    /// <summary>
    /// ���·���
    /// </summary>
    /// <param name="score">��Ҫ�ӵķ���</param>
    public void UpdateScore(int score)
    {
        nowScore += score; 
        labScore.content.text = nowScore.ToString();
    }

    /// <summary>
    /// ����Ѫ��
    /// </summary>
    /// <param name="currentBlood">��ǰѪ��</param>
    /// <param name="maxBlood">���Ѫ��</param>
    public void UpdateBlood(float currentBlood,float maxBlood)
    {
        float nowBlood = (currentBlood / maxBlood) * maxWidth;
        texBlood.poistion.width = nowBlood;
    }

    // Update is called once per frame
    void Update()
    {
        //����ʱ��
        nowTime += Time.deltaTime;
        int time = (int)nowTime;

        labTime.content.text = "";

        if (time / 3600 > 0)
        {
            labTime.content.text += (time / 3600) + "ʱ";
        }

        if ((time % 3600) / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += (time % 3600) / 60 + "��";
        }



        labTime.content.text += time % 60 + "��";
    }
}
