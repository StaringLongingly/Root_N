using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float speed = 100f;
    void FixedUpdate() 
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);    
    }

    void RotateDiv()
    {
        speed /= 1.5f;
    }
}
