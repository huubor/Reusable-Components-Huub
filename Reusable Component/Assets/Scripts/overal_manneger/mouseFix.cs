using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFix : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
