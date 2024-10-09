using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public ButtonGUI buttonGUI;

    public List<LabelGUI> labPM = new ();
    public List<LabelGUI> labName = new ();
    public List<LabelGUI> labScore = new ();
    public List<LabelGUI> labTime = new ();


    private void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            labPM.Add(transform.Find("PM/labPM" + (i + 1)).GetComponent<LabelGUI>());
            labName.Add(transform.Find("Name/labName" + (i + 1)).GetComponent<LabelGUI>());
            labScore.Add(transform.Find("Score/labScore" + (i + 1)).GetComponent<LabelGUI>());
            labTime.Add(transform.Find("Time/labTime" + (i + 1)).GetComponent<LabelGUI>());
        }

        buttonGUI.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instanle.ShowMe();
        };

        //GameDataMgr.Instance.AddRankData("玩家1", 100, 8345);

        HideMe();
    }

    public override void ShowMe()
    {
        UpdateInfo();
        base.ShowMe();
        
    }
    
    /// <summary>
    /// 更新排行榜数据
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void UpdateInfo()
    {
        //获取排行榜的数据
        Rank rank = GameDataMgr.Instance.rank;
        List<RankInfo> ranks = rank.ranks;
        for (int i = 0; i < ranks.Count; i++)
        {
            labName[i].content.text = ranks[i].name;
            labScore[i].content.text = ranks[i].score.ToString();
            int time = (int)ranks[i].time;

            labTime[i].content.text = "";

            if(time/3600 >0)
            {
                labTime[i].content.text += (time / 3600) + "时";
            }
            
            if((time %3600)/60 >0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += (time % 3600) / 60 + "分";
            }
            


            labTime[i].content.text += time % 60 + "秒";
        }
        }

    }




