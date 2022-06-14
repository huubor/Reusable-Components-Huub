using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class walk : MonoBehaviour
{
    [SerializeField] Rigidbody _Rigid;
    [SerializeField] float _Speed = 5f;
    [SerializeField] float _SmoothTime = 0.1f;
    [SerializeField] float _SmoothSpeed = 0.5f;
    [SerializeField] Transform cam;
    private Animator myAnimator;
    public bool _Walking = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        cam = Camera.main.transform;
    }



    void Update()
    {
        //input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        //=========================================================

        //rotation
        float PlayerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, PlayerAngle, ref _SmoothSpeed, _SmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //========================================================================================================

        /*
        //movement
        //W
        if(Input.GetKey(KeyCode.W))
        {
            _Rigid.MovePosition()
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            _Rigid.velocity = Vector3.zero;
        }


        //S
        if (Input.GetKey(KeyCode.S))
        {
            _Rigid.velocity = -transform.forward * _Speed;
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            _Rigid.velocity = Vector3.zero;
        }

        //D
        if (Input.GetKeyDown(KeyCode.D))
        {
            _Rigid.velocity = transform.right * _Speed;
        }

        else if (Input.GetKeyUp(KeyCode.D)){
            _Rigid.velocity = Vector3.zero;
        }

        //A
        if(Input.GetKeyDown(KeyCode.A))
        {
            _Rigid.velocity = -transform.right * _Speed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _Rigid.velocity = Vector3.zero;
        }

       /* else if(horizontal == 0)
        {
            _Rigid.velocity = -transform.right * 0;
            Debug.Log("horizontal" + horizontal);
        }*/
        

        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _Rigid.MovePosition(transform.position + direction * Time.deltaTime * _Speed);
    }
}
