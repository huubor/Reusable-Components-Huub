using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    [SerializeField] GameObject myObject;
    [SerializeField] Vector3 position1;
    [SerializeField] Vector3 position2;
    Vector3 position3;
    [SerializeField] float speed;

    private void Start()
    {
        transform.position = position1;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, position3, speed);
        if (Vector3.Distance(myObject.transform.position, position2) < 0.5f)
        {
            position3 = position1;
        }

        if (Vector3.Distance(myObject.transform.position, position1) < 0.5f)
        {
            position3 = position2;
        }
    }
}
