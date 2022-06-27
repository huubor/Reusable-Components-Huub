using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetJump : MonoBehaviour
{
    private Rigidbody rigid;
    private GroundCheck jumpGround;

    float _force = 1300f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        jumpGround = GetComponent<GroundCheck>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpGround.IsGrounded())
        {
            rigid.AddForce(transform.up * _force);
        }
    }
}
