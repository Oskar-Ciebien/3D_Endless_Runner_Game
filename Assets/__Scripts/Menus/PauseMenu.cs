using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // == Public Fields ==
    public static bool IsPaused = false;
    public GameObject pauseMenu;
    public AudioSource inGameMusic;

    void Update()
    {
        // On press of Escape Key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If PauseMenu is not open
            if (IsPaused == false)
            {
                // Call PauseGame()
                PauseGame();
            }
            // If PauseMenu is open
            else
            {
                // Call ResumeGame()
                ResumeGame();
            }
        }
    } // Update - END

    public void ResumeGame()
    {
        // Disable the PauseMenu
        pauseMenu.SetActive(false);
        // Resume the Game
        Time.timeScale = 1f;
        // Set IsPaused to false = Game Resumed
        IsPaused = false;
    }

    public void MainMenu()
    {
        // Loads the Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    void PauseGame()
    {
        // Show the PauseMenu
        pauseMenu.SetActive(true);
        // Pause the Game
        Time.timeScale = 0f;
        // Set IsPaused to false = Game Paused
        IsPaused = true;
    }

    public void Mute()
    {
        if (inGameMusic.mute == false)
        {
            inGameMusic.mute = true;
        }
        else
        {
            inGameMusic.mute = false;
        }
        // inGameMusic.mute = !inGameMusic.mute;
    }
} // Class - END