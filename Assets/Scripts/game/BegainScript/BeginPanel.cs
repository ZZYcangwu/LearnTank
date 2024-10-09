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
            //�л�����
            SceneManager.LoadScene("GameScene");
        };
        settingBtn.clickEvent += () =>
        {
            //������
            SettingPanel.Instanle.ShowMe();
            HideMe();
            
        };
        quitBtn.clickEvent += () =>
        {
            //�˳���Ϸ
            Application.Quit();
        };
        rankBtn.clickEvent += () =>
        {
            //�����а�
            RankPanel.Instanle.ShowMe();
            HideMe();
        };
    }
}
