using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;

    public TankBase tankBase;

    public GameObject destoryEffctPrefab;//爆炸特效
    
    void Start()
    {
         
    }

    public void SetTank(TankBase tank)
    {
        tankBase = tank;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cute")
        {
            //碰撞前生成特效
            GameObject destoryEffct = Instantiate(destoryEffctPrefab,transform.position,transform.rotation);
            AudioSource audioSource = destoryEffct.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            audioSource.Play();
            Destroy(gameObject);
        }
        
    }
}
