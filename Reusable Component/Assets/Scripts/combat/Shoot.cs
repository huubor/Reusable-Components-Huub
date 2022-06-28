using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] private bool shooting = false;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] Transform myCam;
    private AudioSource mySource;
    private Vector3 bulletSpawnPoint;
    private Quaternion bulletSpawnRotation;

    private void Awake()
    {
        mySource = bulletSpawn.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            shooting = true;
            if (Input.GetKeyDown(KeyCode.Mouse0) && shooting && !mySource.isPlaying)
            {
                mySource.Play();
                var projectile = Instantiate(projectilePrefab, bulletSpawn.transform.position, myCam.rotation);
                projectile.GetComponent<Rigidbody>().velocity = myCam.forward * projectileSpeed;
            }
        }
        else
            shooting = false;
    }
}
