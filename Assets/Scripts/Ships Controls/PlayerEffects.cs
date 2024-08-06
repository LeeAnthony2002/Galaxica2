using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEffects : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab for the explosion effect
    public int lives = 3; // Number of lives
    public Text livesText; // UI Text to display lives
    public Text scoreText; // UI Text to display score
    public Text highScoreText; // UI Text to display high score

    private int score = 0; // Player's score
    private int highScore = 0; // Highest score
    private GameManager gameManager; // Reference to the GameManager

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Load the high score
        UpdateLivesText();
        UpdateScoreText();
        UpdateHighScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile") || other.CompareTag("EnemyShip"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);

            lives = Mathf.Max(lives - 1, 0);
            UpdateLivesText();

            if (lives > 0)
            {
                Debug.Log("Player hit! Lives remaining: " + lives);
            }
            else
            {
                HandleGameOver();
            }
        }
    }

    void HandleGameOver()
    {
        UpdateLivesText();
        CheckHighScore(); // Check and update the high score
        PlayerPrefs.SetInt("PlayerScore", score); // Save the player's score
        gameManager.ShowLeaderboard(score); // Show the leaderboard UI
        Destroy(gameObject); // Destroy the player object
        Debug.Log("Game Over! Showing leaderboard and destroying player...");
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = lives.ToString();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            Debug.Log("Score updated: " + score);
        }
    }

    void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }
    }

    void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }
}