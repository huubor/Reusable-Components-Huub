using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class walk : MonoBehaviour
{
    public event Action OnStartSprint = delegate { };
    public event Action OnStopSprint = delegate { };

    [SerializeField] CharacterController _Controler;
    [SerializeField] float _Speed = 5f;
    [SerializeField] float _SmoothTime = 0.1f;
    [SerializeField] float _SmoothSpeed = 0.5f;
    [SerializeField] Transform cam;
    private Animator myAnimator;
    public bool _Walking = false;

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

        myAnimator.SetBool("walking", _Controler.velocity.magnitude > 0f);

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _SmoothSpeed, _SmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        _Controler.Move(direction * _Speed * Time.deltaTime);
    }
}
