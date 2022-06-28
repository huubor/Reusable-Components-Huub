using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndereDestroyable : MonoBehaviour, IDestroyable
{

    [SerializeField] AudioSource aAudio;
    [SerializeField] AudioSource mySource;
    [SerializeField] AudioClip endTutorial;
    [SerializeField] ParticleSystem pPartical;
    [SerializeField] GameObject myCheckObject;
    private SpecialDestroy myScript;

    private void Awake()
    {
        myScript = myCheckObject.GetComponent<SpecialDestroy>();
    }
    public void DestroyObject()
    {
        if (myScript.canDestroy)
        {
            Destroy(gameObject);
            aAudio.Play();
            pPartical.Play();
            mySource.clip = endTutorial;
            mySource.Play();
        }
    }
}
