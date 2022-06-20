using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetJump : MonoBehaviour
{
    private Rigidbody rigid;

    float _force = 1300f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(transform.up * _force);
        }
    }
}
