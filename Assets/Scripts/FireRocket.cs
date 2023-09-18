using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchVelocity = 10f;
    public float fireRate = 0.25F;
    private float nextFire = 0.0F;
    public bool randomiseAngle;
    public float maxAngle;

    public AudioSource source;
    public AudioClip clip;




    void Update()
    {




        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            source.PlayOneShot(clip);
            float r = Random.Range(-maxAngle, maxAngle);
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchPoint.up * launchVelocity;
        }
    }
}