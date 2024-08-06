using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab for the explosion effect
    public GameObject enemyProjectilePrefab; // Prefab for the enemy projectile
    public Transform projectileSpawnPoint; // Point from which the projectile is fired
    public float shootingInterval = 3f; // Interval between shots
    public float projectileSpeed = 10f; // Speed of the enemy projectile
    public bool canShoot = true; // Whether the enemy can shoot

    private float nextShootTime = 0f; // Time until the next shot can be fired

    void Update()
    {
        if (canShoot && Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootingInterval; // Set the time for the next shot
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the spawn point's position and rotation
        GameObject projectile = Instantiate(enemyProjectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Ensure the projectile has a Rigidbody component
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.back * projectileSpeed; // Set the velocity to move towards the player
            Debug.Log("Projectile shot with velocity: " + rb.velocity);
        }
        else
        {
            Debug.LogError("No Rigidbody found on the projectile!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a player projectile
        if (other.CompareTag("PlayerProjectile"))
        {
            // Instantiate explosion effect at the enemy's position and rotation
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Destroy the enemy and the projectile
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}