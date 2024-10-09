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

    public int nowScore = 0;//当前分数
    public float maxWidth;//血条最大宽度
    public float nowTime;
    void Start()
    {
        //监听按钮事件
        //设置设置按钮
        btnSetting.clickEvent += ()=>{
            SettingPanel.Instanle.ShowMe();
        };
        //设置退出按钮
        btnQuit.clickEvent += () => {
            //打开提示框
            QuitPanel.Instanle.ShowMe();
        };
        UpdateBlood(10,100);
        UpdateScore(100);
    }


    /// <summary>
    /// 更新分数
    /// </summary>
    /// <param name="score">需要加的分数</param>
    public void UpdateScore(int score)
    {
        nowScore += score; 
        labScore.content.text = nowScore.ToString();
    }

    /// <summary>
    /// 更新血条
    /// </summary>
    /// <param name="currentBlood">当前血量</param>
    /// <param name="maxBlood">最大血量</param>
    public void UpdateBlood(float currentBlood,float maxBlood)
    {
        float nowBlood = (currentBlood / maxBlood) * maxWidth;
        texBlood.poistion.width = nowBlood;
    }

    // Update is called once per frame
    void Update()
    {
        //处理时间
        nowTime += Time.deltaTime;
        int time = (int)nowTime;

        labTime.content.text = "";

        if (time / 3600 > 0)
        {
            labTime.content.text += (time / 3600) + "时";
        }

        if ((time % 3600) / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += (time % 3600) / 60 + "分";
        }



        labTime.content.text += time % 60 + "秒";
    }
}
