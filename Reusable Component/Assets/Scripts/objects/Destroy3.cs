using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy3 : MonoBehaviour, IDestroyable
{
    [SerializeField] ParticleSystem pPartical;
    public void DestroyObject()
    {
        Destroy(gameObject);
        pPartical.Play();
    }
}
