using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagging : MonoBehaviour
{
    public float frequency = 2f; // Frequency of the zigzag pattern
    public float amplitude = 5f; // Amplitude of the zigzag pattern

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Debug.Log("ZigZagging script started on: " + gameObject.name);
    }

    void Update()
    {
        // Calculate the new position with zigzag pattern only
        float x = startPosition.x + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(x, transform.position.y, startPosition.z);

        Debug.Log("ZigZagging position: " + transform.position);

        // Optionally destroy the enemy when it goes off-screen
        if (transform.position.z < -10f) // Adjust based on your game setup
        {
            Destroy(gameObject);
            Debug.Log("ZigZagging enemy destroyed (off-screen).");
        }
    }
}