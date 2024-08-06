using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    public float lifetime = 5f; // Lifetime in seconds
    public float offScreenDistance = 15f; // Distance from the center to consider off-screen

    private void Start()
    {
        // Destroy the projectile after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Check if the projectile has gone off-screen
        if (Mathf.Abs(transform.position.x) > offScreenDistance ||
            Mathf.Abs(transform.position.y) > offScreenDistance ||
            Mathf.Abs(transform.position.z) > offScreenDistance)
        {
            Destroy(gameObject);
        }
    }
}