using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject hitFX;
    //[SerializeField] Transform parrent;
    [SerializeField] int pointsHit = 100;
    [SerializeField] int numberOfHits = 1;

    ScoreBoard scoreBoard;
    GameObject parrentGameObject;



    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parrentGameObject = GameObject.FindWithTag("SpavnAtRuntime");
        AddRigidbody();
    }

     void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (numberOfHits <= 0)
        {
            KillEnemy();
        }
          
        
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parrentGameObject.transform;
        scoreBoard.IncreaceScore(pointsHit);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parrentGameObject.transform;
        numberOfHits--;
        //scoreBoard.IncreaceScore(pointsHit);
        Debug.Log(numberOfHits);
    }
}
