using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    [SerializeField] GameObject myObject;
    [SerializeField] Vector3 scale1;
    [SerializeField] Vector3 scale2;
    [SerializeField] float scaleSpeed;

    private Vector3 scale3;

    private void Start()
    {
        myObject.transform.localScale = scale1;

        scale1 = transform.localScale;
        scale3 = scale2;
    }

    void Update()
    {
        myObject.transform.localScale = Vector3.Slerp(transform.localScale, scale3, scaleSpeed * Time.deltaTime);

        if (Vector3.Distance(myObject.transform.localScale, scale2) < 0.5f)
        {
            scale3 = scale1;
        }

        if (Vector3.Distance(myObject.transform.localScale, scale1) < 0.5f)
        {
            scale3 = scale2;
        }
    }
}
