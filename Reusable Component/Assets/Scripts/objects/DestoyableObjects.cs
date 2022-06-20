using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyableObjects : MonoBehaviour, IDestroyable
{
    
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
