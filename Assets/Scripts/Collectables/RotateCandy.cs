using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCandy : MonoBehaviour
{
   private float rotateSpeed = 1;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
