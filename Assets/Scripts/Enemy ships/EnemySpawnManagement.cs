using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManagement : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 2f; // Time between enemy spawns
    public float xMin = -5f; // Minimum x position
    public float xMax = 5f;  // Maximum x position
    public float spawnZ = 10f; // Z position where enemies spawn (adjust this value)

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval; // Set the time for the next spawn
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random x position within the defined range
        float xPos = Random.Range(xMin, xMax);

        // Create the spawn position based on the calculated x and fixed z
        Vector3 spawnPosition = new Vector3(xPos, 0f, spawnZ);

        // Instantiate the enemy at the spawn position
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Randomly assign a movement pattern
        int pattern = Random.Range(0, 3); // 0 for straight, 1 for zigzag, 2 for circle
        if (pattern == 0)
        {
            enemy.AddComponent<StraightMovement>();
            enemy.GetComponent<EnemyControls>().canShoot = true; // Enable shooting
            Debug.Log("Added StraightMovement to enemy.");
        }
        else if (pattern == 1)
        {
            enemy.AddComponent<ZigZagging>();
            enemy.GetComponent<EnemyControls>().canShoot = false; // Disable shooting
            Debug.Log("Added ZigZagging to enemy.");
        }
        else
        {
            enemy.AddComponent<DoACircle>();
            enemy.GetComponent<EnemyControls>().canShoot = false; // Disable shooting
            Debug.Log("Added DoACircle to enemy.");
        }
    }
}