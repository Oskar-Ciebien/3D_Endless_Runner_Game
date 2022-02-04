using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    // == Public Fields ==
    public static GameData singleton;
    public Text scoreText = null;
    public static int sharedScore = 0; // Used for showing score to other scripts

    // == Private Fields ==
    private int score = 0;

    private void Awake()
    {
        // Create singleton
        GameObject[] go = GameObject.FindGameObjectsWithTag("GameData");

        // If there is more than one GameData
        if (go.Length > 1)
        {
            // Destroy it
            Destroy(this.gameObject);
        }
        else // Otherwise
        {
            // Don't destroy it
            DontDestroyOnLoad(this.gameObject);
            // Set it as Singleton
            singleton = this;
        }
        // Display score to the text
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();

        // print(score); // Used for testing
        // print(PlayerPrefs.GetInt("Score")); // Used for testing
    } // Awake END

    // Updates the Score on the screen
    public void UpdateScore(int s)
    {
        // Update the score into PlayerPrefs
        PlayerPrefs.SetInt("Score", score += s);
        sharedScore = score;

        // If scoreText is not null
        if (scoreText != null)
        {
            // Set the new score to the text
            scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    } // UpdateScore END

    // Reset Score Variables
    public void ResetScore()
    {
        score = 0;
        sharedScore = 0;
    }
} // Class - END