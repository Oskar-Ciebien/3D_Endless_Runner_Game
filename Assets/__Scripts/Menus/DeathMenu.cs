using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    // == Public Fields ==
    public Text finalScoreText = null;

    // == Private Fields ==
    private int score = 0;
    private int startScore = 0;

    public void MainMenu()
    {
        // Load Main Menu Scene
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        // Restarts the Game
        SceneManager.LoadScene("GameScene");
        // Reset Player
        PlayerBehaviour.ResetPlayer();
        // Reset Score in GameData
        GameData.singleton.ResetScore();
    }

    private void Awake()
    {
        // print(score); // Used for testing
        // print(PlayerPrefs.GetInt("Score")); // Used for testing

        // Set score to the sharedScore from GameData
        score = GameData.sharedScore;
        // Display the score on the screen
        finalScoreText.text = score.ToString();
    }

} // Class - END
