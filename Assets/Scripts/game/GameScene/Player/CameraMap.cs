using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMap : MonoBehaviour
{
    public Transform Player;
    public int height;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Player == null) return;
        Vector3 pos = new Vector3();
        pos.x = Player.transform.position.x;
        pos.z = Player.transform.position.z;
        pos.y = height;
        transform.position = pos;

        
    }
}
