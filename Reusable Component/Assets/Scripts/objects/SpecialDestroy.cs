using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDestroy : MonoBehaviour, IDestroyable
{
    public bool canDestroy = false;
    public void DestroyObject()
    {
        canDestroy = true;
        Destroy(gameObject);
    }
}
