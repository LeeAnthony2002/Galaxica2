using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingControl : MonoBehaviour
{
   public GameObject projectilePrefab; // The projectile prefab (Capsule)
    public Transform projectileSpawnPoint; // The point from which the projectile is fired
    public float projectileSpeed = 10f; // Speed of the projectile
    public float fireRate = 0.5f; // Time between shots
    private float nextFireTime = 0f; // Time until the next shot can be fired

    void Update()
    {
        // Check if the player presses the space bar and if enough time has passed to shoot again
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Set the time for the next allowed shot
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the spawn point's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Get the Rigidbody component of the projectile and set its velocity
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
         rb.velocity = Vector3.forward * projectileSpeed; // Projectiles move straight on the z-axis
    }
}
