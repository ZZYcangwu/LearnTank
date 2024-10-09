using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();

    public static GameDataMgr Instance => instance;

    public MusciData musicData;

    public Rank rank;



    private  GameDataMgr()
    {
        musicData  = PlayerPrefsUtil.Instance.LoadData(typeof(MusciData), "Music") as MusciData;
        
        if(!musicData.isFirstLoad)
        {
           
            musicData.isFirstLoad = true;
            musicData.isMusic = true;
            musicData.isSound = true;
            musicData.soundValue = 1;
            musicData.musicVaule = 1;
            PlayerPrefsUtil.Instance.SaveData(musicData, "Music");
        }

        //加载排行榜数据
        rank = PlayerPrefsUtil.Instance.LoadData(typeof(Rank),"Rank") as Rank;
    }

    public void AddRankData(string name,int score,float time)
    {
        rank.AddRankInfo(new RankInfo(name, score, time));
        //排序
        rank.ranks.Sort((a, b) =>(a.score - b.score));
        for(int i = rank.ranks.Count - 1; i>=10; i--)
        {
            rank.ranks.RemoveAt(i);
        }
        PlayerPrefsUtil.Instance.SaveData(rank, "Rank");
    }

    public void SetMusicSelected(bool select)
    {
        musicData.isMusic = select;
        PlayerPrefsUtil.Instance.SaveData(musicData, "Music");
    }
    public void SetSoundSelected(bool select)
    {
        musicData.isSound = select;
        PlayerPrefsUtil.Instance.SaveData(musicData, "Music");
    }

    public void SetMusicValue(float value)
    {
        musicData.musicVaule = value;
        PlayerPrefsUtil.Instance.SaveData(musicData, "Music");
    }
    public void SetSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsUtil.Instance.SaveData(musicData, "Music");
    }


}
