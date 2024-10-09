using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGame : MonoBehaviour
{
    public float rotationSpeed = 10;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
