using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndereDestroyable : MonoBehaviour, IDestroyable
{

    [SerializeField] AudioSource aAudio;
    [SerializeField] ParticleSystem pPartical;
    public void DestroyObject()
    {
        Destroy(gameObject);
        aAudio.Play();
        pPartical.Play();
        Debug.Log("test");
    }
}
