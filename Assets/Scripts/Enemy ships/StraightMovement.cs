using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy

    void Update()
    {
        // Move the enemy straight towards the player
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Optionally destroy the enemy when it goes off-screen
        if (transform.position.z < -10f) // Adjust based on your game setup
        {
            Destroy(gameObject);
        }
    }
}