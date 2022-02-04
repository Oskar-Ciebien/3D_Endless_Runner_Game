using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Transfers the player to the game scene (the next index scene)
    public void Play()
    {
        // Reset Lives
        PlayerPrefs.SetInt("LivesLeft", PlayerBehaviour.startLives);

        // Reset Score
        PlayerPrefs.SetInt("Score", PlayerBehaviour.startScore);

        // Loads the gamescene and begins the game
        SceneManager.LoadScene("GameScene");
    }

    // Exits out of the game
    public void Exit()
    {
        // Quits the game
        Application.Quit();
    }
} // Class - END
