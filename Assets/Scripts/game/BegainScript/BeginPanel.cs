using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public ButtonGUI beginBtn;
    public ButtonGUI settingBtn;
    public ButtonGUI quitBtn;
    public ButtonGUI rankBtn;

    private void Start()
    {
        beginBtn.clickEvent += () =>
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        settingBtn.clickEvent += () =>
        {
            //打开设置
            SettingPanel.Instanle.ShowMe();
            HideMe();
            
        };
        quitBtn.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        rankBtn.clickEvent += () =>
        {
            //打开排行榜
            RankPanel.Instanle.ShowMe();
            HideMe();
        };
    }
}
