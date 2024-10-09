using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TankBase
{
    

    public override void Fire()
    {
       
    }

    public override void Dead()
    {
        base.Dead();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));//坦克前进
        transform.Rotate(Vector3.up * rotaSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));//坦克旋转

        weaponMount.Rotate(Vector3.up * barrelSpeed  *  Input.GetAxis("Mouse X"));

        //鼠标按下开火
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (GamePanel.Instanle.nowTime > 4)
        {
            Dead();
        }

    }
    /// <summary>
    /// 更新血条
    /// </summary>
    public override void LoseBlood(TankBase tankBase)
    {
        base.LoseBlood(tankBase);
        GamePanel.Instanle.UpdateBlood(Hp, maxHp);
    }

   

}
