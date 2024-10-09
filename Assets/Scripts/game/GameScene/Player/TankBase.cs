using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坦克基类
/// </summary>
public abstract class TankBase : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public int attack;
    public int defense;

    public float moveSpeed;
    public float rotaSpeed;
    public float barrelSpeed;

    public Transform weaponMount;

    public GameObject deadEffect;
    public abstract void Fire();

    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="damage"></param>
    public virtual void LoseBlood(TankBase tankBase)
    {
        float loseBlood = tankBase.attack - defense;
        if (loseBlood > 0)
        {
            this.Hp -= loseBlood;
        }
        if (Hp < 0)
        {
            Dead();
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public virtual void Dead()
    {
        Destroy(this.gameObject);
        GameObject gameObject1 = Instantiate(deadEffect, this.transform.position,transform.rotation);

        AudioSource audioSource = gameObject1.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
        audioSource.Play();
    }
}
