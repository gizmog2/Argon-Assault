using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollaiderHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We colided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSecuence();
        Debug.Log("We triggered with " + other.gameObject.name);
    }

    void StartCrashSecuence()
    {
        DisableMovement();
        Invoke("ReloadLevel", 1f);
    }

    void DisableMovement()
    {
        GetComponent<PlayerController>().enabled = false;
    }

    void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
