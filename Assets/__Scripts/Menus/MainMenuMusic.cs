using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusic : MonoBehaviour
{
    // == Serialize Fields ==
    [SerializeField] Slider slider;

    // == Private Fields ==
    private float defaultVolume = 0.352f;

    void Start()
    {
        // If the Music has not been changed by the player
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            // Set to defaultVolume
            PlayerPrefs.SetFloat("musicVolume", defaultVolume);
            Load();
        }
        // Otherwise
        else
        {
            // Load players previously saved volume
            Load();
        }
    } // Start - END

    // Changes the Volume of the Music
    public void ChangeVolume()
    {
        // Change Volume of the music compared with the slider
        AudioListener.volume = slider.value;
        // Calls Save()
        Save();
    }

    // Loads the previous Music Volume
    private void Load()
    {
        // Sets the slider to the same value as musicVolume
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // Saves the Volume of the Music
    private void Save()
    {
        // Save volume from the slider, will be used next time the game is played
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
} // Class - END