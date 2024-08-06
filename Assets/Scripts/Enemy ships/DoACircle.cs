using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoACircle : MonoBehaviour
{
    public float speed = 3f; // Speed of the circular movement
    public float radius = 15f; // Radius of the circle

    private float angle = 0f; // Current angle in radians
    private Vector3 center; // Center point of the circular path

    void Start()
    {
        // Set the center point to be a certain distance in front of the enemy
        center = transform.position + Vector3.forward * radius;
    }

    void Update()
    {
        // Update the angle based on the speed
        angle += speed * Time.deltaTime;

        // Calculate the new position using sine and cosine functions for a circular path
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Update the position of the enemy
        transform.position = new Vector3(center.x + x, transform.position.y, center.z + z);

        // Optionally destroy the enemy when it goes off-screen
        if (transform.position.z < -10f) // Adjust based on your game setup
        {
            Destroy(gameObject);
            Debug.Log("DoACircle enemy destroyed (off-screen).");
        }
    }
}
