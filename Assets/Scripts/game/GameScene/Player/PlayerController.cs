using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TankBase
{
    public WeaponObj weapon;

    public override void Fire()
    {
        weapon.Fire();
    }

    public override void Dead()
    {
        base.Dead();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));//̹��ǰ��
        transform.Rotate(Vector3.up * rotaSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));//̹����ת

        weaponMount.Rotate(Vector3.up * barrelSpeed  *  Input.GetAxis("Mouse X"));

        //��갴�¿���
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        

    }
    /// <summary>
    /// ����Ѫ��
    /// </summary>
    public override void LoseBlood(TankBase tankBase)
    {
        base.LoseBlood(tankBase);
        GamePanel.Instanle.UpdateBlood(Hp, maxHp);
    }

   

}
