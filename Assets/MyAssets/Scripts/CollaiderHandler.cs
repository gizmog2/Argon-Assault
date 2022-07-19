using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaiderHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We colided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We triggered with " + other.gameObject.name);
    }
}
