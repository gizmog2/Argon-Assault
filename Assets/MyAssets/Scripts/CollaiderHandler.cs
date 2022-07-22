using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollaiderHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] GameObject shipCollider;
    [SerializeField] float reloadTime = 1f;

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
        GetComponent<MeshRenderer>().enabled = false;
        shipCollider.SetActive(false);
        DisableMovement();
        Invoke("ReloadLevel", reloadTime);
        crashParticles.Play();
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
