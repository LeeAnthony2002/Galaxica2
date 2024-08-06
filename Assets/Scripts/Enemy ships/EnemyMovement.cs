using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed =+ 2f; // Speed of the enemy

    void Update()
    {
        // Move the enemy towards the player on the z-axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Optionally destroy the enemy when it goes past the player
        if (transform.position.z < -10f) // Adjust based on your game setup
        {
            Destroy(gameObject);
        }
    }
}
