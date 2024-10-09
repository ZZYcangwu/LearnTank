using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public ButtonGUI btnClose;

    public ToogleGUI togMusic;
    public ToogleGUI togSound;

    public SliderGUI slidNusic;
    public SliderGUI slidSound;


    private void Start()
    {
        btnClose.clickEvent += () =>
        {
            //关闭按钮
            HideMe();
            if(SceneManager.GetActiveScene().name == "BeginGame")
            {
                BeginPanel.Instanle.ShowMe();
            }
            
        };

        togMusic.changeEvent += (value) =>
        {
            //改变音乐设置
            GameDataMgr.Instance.SetMusicSelected(value);
            BakMusic.Instance.IsMute(value);
        };

        togSound.changeEvent += (value) =>
        {
            //改变音效设置
            GameDataMgr.Instance.SetSoundSelected(value);
        };

        slidNusic.OnValueChanged += (value) =>
        {
            //改变音乐设置
            GameDataMgr.Instance.SetMusicValue(value);
            BakMusic.Instance.SetBakMusic(value);
        };

        slidSound.OnValueChanged += (value) =>
        {
            //改变音效设置
            GameDataMgr.Instance.SetSoundValue(value);
        };

        HideMe();
    }

    public void SetMusicData()
    {
        MusciData musicData = GameDataMgr.Instance.musicData;
        togMusic.isSelect =  musicData.isMusic;
        togSound.isSelect =  musicData.isSound;
        slidNusic.value = musicData.musicVaule;
        slidSound.value = musicData.soundValue;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        SetMusicData();
    }
}
