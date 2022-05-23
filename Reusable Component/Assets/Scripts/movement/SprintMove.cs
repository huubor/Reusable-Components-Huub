using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SprintMove : MonoBehaviour
{
    public event Action OnStartSprint = delegate { };
    public event Action OnStopSprint = delegate { };

    [SerializeField] CharacterController _Controler;
    [SerializeField] float _Speed = 5f;
    [SerializeField] float _SmoothTime = 0.1f;
    [SerializeField] float _SmoothSpeed = 0.5f;
    [SerializeField] Transform cam;
    private Animator myAnimator;

    private bool boolSrint = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        _Controler = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }



    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

            //player faces the camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _SmoothSpeed, _SmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //following the camera (doesn't work, it keeps on walking with this)
            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            //moving of the player
            if (Input.GetKey(KeyCode.W) && !boolSrint || Input.GetKey(KeyCode.A) && !boolSrint || Input.GetKey(KeyCode.S) && !boolSrint || Input.GetKey(KeyCode.D) && !boolSrint)
            {
                _Controler.Move(moveDirection * _Speed * Time.deltaTime);
                myAnimator.SetBool("walking", true);
            }
            else 
            myAnimator.SetBool("walking", false);

        //sprint check
        if (Input.GetKey(KeyCode.LeftShift))
        {
            boolSrint = true;
            if (Input.GetKey(KeyCode.W) && boolSrint || Input.GetKey(KeyCode.A) && boolSrint || Input.GetKey(KeyCode.S) && boolSrint || Input.GetKey(KeyCode.D) && boolSrint)
            {
                _Controler.Move(moveDirection * (_Speed * 10) * Time.deltaTime);
                myAnimator.SetBool("sprinting", true);
            }
            else
            {
                myAnimator.SetBool("sprinting", false);
            }
        }
        else
        {
            boolSrint = false;
            myAnimator.SetBool("sprinting", false);
        }
    }
}
