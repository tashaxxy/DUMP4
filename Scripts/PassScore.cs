using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassScore : MonoBehaviour
{
    public Text passText;
    public int scoreToBeat = 100; // Default score to beat

    // Function to update the score to beat
    public void UpdateScoreToBeat(int newScoreToBeat)
    {
        scoreToBeat = newScoreToBeat;
        UpdateScoreText();
    }

    // Function to update the score text display
    void UpdateScoreText()
    {
        passText.text = "Score to Pass: " + scoreToBeat;
    }

    // Example usage: Call this function whenever you change levels or update the score to beat
    void Start()
    {
        UpdateScoreText(); // Update the text when the game starts
    }
}
