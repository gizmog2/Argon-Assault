using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Transform parrent;

    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parrent;
        Destroy(gameObject);
    }
}
