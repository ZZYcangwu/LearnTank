using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ű�
/// </summary>
public class WeaponObj : MonoBehaviour
{
    public GameObject bulletPrefab;//�ӵ�Ԥ����

    public Transform[] muzzle;//ǹ��

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
    /// ����
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
