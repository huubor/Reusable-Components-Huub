using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] private bool shooting = false;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform myCam;
    private Vector3 bulletSpawnPoint;
    private Quaternion bulletSpawnRotation;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            shooting = true;
            if (Input.GetKeyDown(KeyCode.Mouse0) && shooting)
            {
                var projectile = Instantiate(projectilePrefab, bulletSpawn.position, myCam.rotation);
                projectile.GetComponent<Rigidbody>().velocity = myCam.forward * projectileSpeed;
            }
        }
        else
            shooting = false;
    }
}
