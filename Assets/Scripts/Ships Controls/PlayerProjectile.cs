using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int scoreValue = 1000; // Score value for hitting an enemy
    public GameObject explosionPrefab; // Prefab for the explosion effect

    private PlayerEffects playerEffects; // Reference to the PlayerEffects script

    void Start()
    {
        // Find the PlayerEffects script in the scene
        playerEffects = FindObjectOfType<PlayerEffects>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyShip"))
        {
            // Instantiate explosion effect
            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);

            // Destroy the enemy and the projectile
            Destroy(other.gameObject);
            Destroy(gameObject);

            // Increase the player's score
            playerEffects.AddScore(scoreValue);
        }
    }
}