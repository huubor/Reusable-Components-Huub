using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float life = 3;


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IDestroyable>()?.DestroyObject();

        Destroy(gameObject);
    }
}
