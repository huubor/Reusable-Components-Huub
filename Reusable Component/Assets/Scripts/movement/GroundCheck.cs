using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float distToGround = 1f;
    [SerializeField] GameObject pPlayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;


    public bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, 1f, ground);
    }
}
