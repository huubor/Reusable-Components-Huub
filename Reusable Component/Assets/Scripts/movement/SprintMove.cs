using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SprintMove : MonoBehaviour
{
    public event Action OnStartSprint = delegate { };
    public event Action OnStopSprint = delegate { };

    private Rigidbody rigid;
    [SerializeField] public float _Speed = 50f;
    [SerializeField] float _SmoothTime = 0.1f;
    [SerializeField] float _SmoothSpeed = 0.5f;
    [SerializeField] Transform cam;
    
    private float jumpFloat = 10f;
    public Vector3 JumpVector;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigid.MovePosition(transform.position + movedir * Time.deltaTime * _Speed * 2);
            }
            else

                rigid.MovePosition(transform.position + movedir * Time.deltaTime * _Speed);
        }
    }
}
