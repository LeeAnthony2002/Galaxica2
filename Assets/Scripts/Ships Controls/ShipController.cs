using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f; // Speed of the player's ship
    public float xMin = -5f; // Minimum x position
    public float xMax = 5f;  // Maximum x position

    void Update()
    {
        // Get the horizontal input (A/D keys or Left/Right arrows)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        // Apply the movement to the player's position
        transform.Translate(movement * speed * Time.deltaTime);

        // Clamp the player's position to the screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Reset rotation to zero each frame to prevent unintended rotation
        transform.rotation = Quaternion.identity;
    }
}
