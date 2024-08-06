using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissiles : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile

    void Start()
    {
        // Set the projectile to move forward at the specified speed
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed; // Set the velocity to move towards the player
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Destroy the player and the projectile
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
