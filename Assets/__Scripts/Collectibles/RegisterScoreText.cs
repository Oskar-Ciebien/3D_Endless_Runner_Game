using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScoreText : MonoBehaviour
{
    void Update()
    {
        // Call RegisterScore()
        RegisterScore();
    }

    public void RegisterScore()
    {
        // Display the Score from GameData on Screen
        GameData.singleton.scoreText = this.GetComponent<Text>();
    }
} // Class - END
