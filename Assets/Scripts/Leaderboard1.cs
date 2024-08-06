using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text scoreText; // Text to display the player's score
    public Text[] leaderboardScores; // Text fields for top 4 scores
    public Button resetButton; // Reset button
    public Button quitButton; // Quit button

    void Start()
    {
        // Assign button click listeners
        resetButton.onClick.AddListener(OnResetButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);

        // Load and display the player's score
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = playerScore.ToString();

        // Load and display the leaderboard scores
        UpdateLeaderboard(playerScore);
    }

    void UpdateLeaderboard(int newScore)
    {
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

    public void OnResetButtonClick()
    {
        Debug.Log("Reset button clicked"); // Debug log for button click
        SceneManager.LoadScene("GameScene"); // Load the game scene
    }

    public void OnQuitButtonClick()
    {
        Debug.Log("Quit button clicked"); // Debug log for button click
        Application.Quit(); // Quit the application 
    }
}