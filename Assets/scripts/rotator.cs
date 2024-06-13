using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float speed = 100f;
    public int isRotatingToTheRight;

    void Start()
    {
        isRotatingToTheRight = UnityEngine.Random.Range(0,2) * 2 - 1;
    }
    void FixedUpdate() 
    {
        transform.Rotate(0f, 0f, speed * isRotatingToTheRight * Time.deltaTime);    
    }

    void RotateDiv()
    {
        speed /= 1.5f;
    }
}
