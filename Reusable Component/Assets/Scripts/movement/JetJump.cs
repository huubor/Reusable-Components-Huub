using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetJump : MonoBehaviour
{
    private Rigidbody rigid;
    private bool canJump = true;

    float _force = 1000f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(transform.up * _force);
        }
    }
}
