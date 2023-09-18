using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchFruit : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchVelocity = 10f;
  

    




    public void Launch()
    {
        var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
        _projectile.GetComponent<Rigidbody>().velocity = launchPoint.up * launchVelocity;  
    }
}