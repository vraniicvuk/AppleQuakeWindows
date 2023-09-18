using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject, 0.1f);
            source.PlayOneShot(clip);
        }
    }
}
