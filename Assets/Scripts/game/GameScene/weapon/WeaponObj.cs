using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器脚本
/// </summary>
public class WeaponObj : MonoBehaviour
{
    public GameObject bulletPrefab;//子弹预制体

    public Transform[] muzzle;//枪口

    public TankBase fatherObj;

    public void SetFather(TankBase obj)
    {
        fatherObj = obj;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// 开火
    /// </summary>
    public void Fire()
    {
        foreach(Transform tsf in muzzle)
        {
            GameObject bullet = Instantiate(bulletPrefab, tsf.position,tsf.rotation);
            Bullet bul = bullet.GetComponent<Bullet>();
            bul.SetTank(fatherObj);
            
        }
        
    }
}
