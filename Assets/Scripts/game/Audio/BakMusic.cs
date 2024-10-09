using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakMusic : MonoBehaviour
{
    private static BakMusic instance;

    public static BakMusic Instance=>instance;

    private AudioSource m_AudioSource;

    private void Awake()
    {
        instance = this;
        m_AudioSource = GetComponent<AudioSource>();
        SetBakMusic(GameDataMgr.Instance.musicData.musicVaule);
        IsMute(GameDataMgr.Instance.musicData.isMusic);
    }

    /// <summary>
    /// …Ë÷√“Ù¡ø
    /// </summary>
    /// <param name="bakMusic"></param>
    public void SetBakMusic(float bakMusic)
    {
        m_AudioSource.volume = bakMusic;
    }

    /// <summary>
    /// …Ë÷√æ≤“Ù
    /// </summary>
    /// <param name="isMute"></param>
    public void IsMute(bool isMute)
    {
        m_AudioSource.mute = !isMute;
    }
}
