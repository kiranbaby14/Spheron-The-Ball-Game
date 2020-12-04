using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCubes : MonoBehaviour
{
    public float rotationRate = 200f;


    void FixedUpdate()
    {
        transform.Rotate(Vector3.down, rotationRate * Time.deltaTime);
    }
}
