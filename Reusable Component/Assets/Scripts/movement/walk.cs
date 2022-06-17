using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class walk : MonoBehaviour
{
    [SerializeField] Rigidbody _Rigid;
    [SerializeField] float _Speed = 50f;
    [SerializeField] float _SmoothTime = 0.1f;
    [SerializeField] float _SmoothSpeed = 0.5f;
    [SerializeField] Transform cam;
    public bool _Walking = false;

    private void Awake()
    {
        cam = Camera.main.transform;
    }



    void Update()
    {
        //input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        //=========================================================

        //rotation player
        float PlayerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, PlayerAngle, ref _SmoothSpeed, _SmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //========================================================================================================   

        Vector3 movedir = Quaternion.Euler(0f, PlayerAngle, 0f) * Vector3.forward;

        //moving
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _Rigid.MovePosition(transform.position + movedir * Time.deltaTime * _Speed);
        }
    }
}
