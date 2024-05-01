using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SchoolScore : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;
    private int highestScore = 0;
    public int startingLives = 3;
    public GameObject[] hearts;
    public string correctTrashTag = "bio";
    public GameObject canvas; // Reference to the Canvas GameObject
    public GameObject spawner; // Reference to the spawner GameObject
    public GameObject gameOverPanel; // Reference to the game over panel GameObject

    private int remainingLives;
    private bool gameOver = false; // Flag to track if the game is over

    public int[] levelScoreThresholds;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: 0";

        remainingLives = startingLives;
        UpdateHearts();
        gameOverPanel.SetActive(false); // Deactivate the game over panel at the start

        // Load highest score from player prefs
        highestScore = PlayerPrefs.GetInt("SchoolHighestScore", 0);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (!gameOver) // Only allow scoring when the game is not over
        {
            if (target.CompareTag(correctTrashTag))
            {
                target.gameObject.SetActive(false);
                score += 10;
                scoreText.text = "Score: " + score.ToString();

                UnlockNewLevel();
            }
            else
            {
                // If wrong trash is collected, reduce the life count
                ReduceLife();
            }
        }
    }

    void ReduceLife()
    {
        if (remainingLives > 0)
        {
            remainingLives--;
            UpdateHearts();
        }
        else
        {
            // Game over logic
            GameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < remainingLives)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    void GameOver()
    {
        gameOver = true; // Set the game over flag

        // Activate the game over panel
        gameOverPanel.SetActive(true);

        // Deactivate spawner to stop spawning fruits
        spawner.SetActive(false);

        // Update current score text
        Text currentScoreText = gameOverPanel.transform.Find("CurrentScoreText").GetComponent<Text>();
        currentScoreText.text = "Score: " + score.ToString();

        // Find and update the highest score text
        Text highestScoreText = gameOverPanel.transform.Find("HighestScoreText").GetComponent<Text>();
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("SchoolHighestScore", highestScore);
            PlayerPrefs.Save(); // Ensure that PlayerPrefs data is saved immediately
            Debug.Log("HighestScoreText found and updated successfully!");
        }
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    void UnlockNewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel < levelScoreThresholds.Length)
        {
            int threshold = levelScoreThresholds[currentLevel];
            if (score >= threshold)
            {
                // Unlock the next level
                int nextLevelIndex = currentLevel + 1;
                PlayerPrefs.SetInt("UnlockedLevelKey", nextLevelIndex);
                PlayerPrefs.Save();
            }

        }

    }
}