using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycle : MonoBehaviour
{
    [SerializeField] GameObject myGameobject;
    Transform myTransform;

    private void Awake()
    {
        myTransform = myGameobject.GetComponent<Transform>();
    }
    void Update()
    {
        myTransform.Rotate(new Vector3(1,0,0) * Time.deltaTime /2);
    }
}
