using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation : MonoBehaviour
{
    [SerializeField] float rotatingSpeed, xAngle, yAngle, zAngle;


    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
