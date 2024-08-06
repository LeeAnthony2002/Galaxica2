using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject leaderboardUI; // Leaderboard UI panel
    public Text scoreText; // Text to display the player's score
    public Text[] leaderboardScores; // Text fields for top 4 scores
    public Button resetButton; // Reset button
    public Button quitButton; // Quit button

    private bool isGamePaused = false; // Game state variable

    void Start()
    {
        // Ensure the leaderboard UI is initially disabled
        leaderboardUI.SetActive(false);

        // Assign button click listeners
        resetButton.onClick.AddListener(OnResetButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGamePaused)
        {
            ResetGame();
        }
    }

    public void ShowLeaderboard(int newScore)
    {
        Debug.Log("ShowLeaderboard called"); // Log when ShowLeaderboard is called
        leaderboardUI.SetActive(true); // Enable the leaderboard UI
        UpdateLeaderboard(newScore); // Update the leaderboard with the new score
        PauseGame();
    }

    void UpdateLeaderboard(int newScore)
    {
        scoreText.text = newScore.ToString(); // Display the player's score

        int[] scores = new int[5]; // Array to store the top 4 scores and the new score
        for (int i = 0; i < 4; i++)
        {
            scores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
        }
        scores[4] = newScore; // Add the new score to the array

        System.Array.Sort(scores);
        System.Array.Reverse(scores);

        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, scores[i]);
            leaderboardScores[i].text = (i + 1) + ". " + scores[i];
        }

        Debug.Log("Leaderboard updated with new score: " + newScore);
    }

    void PauseGame()
    {
        Debug.Log("PauseGame called"); // Log when PauseGame is called
        Time.timeScale = 0; // Pause the game
        isGamePaused = true; // Update the game state
        Debug.Log("Game Paused: Time.timeScale = " + Time.timeScale); // Log the Time.timeScale value
    }

    public void ResetGame()
    {
        Debug.Log("ResetGame called"); // Debug log for button click
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void OnResetButtonClick()
    {
        Debug.Log("Reset button clicked"); // Debug log for button click
        ResetGame();
    }

    void OnQuitButtonClick()
    {
        Debug.Log("Quit button clicked"); // Debug log for button click
        QuitGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game called"); // Log to verify the button press in the editor
        Application.Quit(); // Quit the application
    }
}