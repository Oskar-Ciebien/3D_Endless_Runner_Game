using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    // == Public Fields ==
    public Text countdownText;
    // == Private Fields ==
    private int seconds = 0;

    private void Start()
    {
        // If countdownText is not active and not enabled
        if (countdownText.isActiveAndEnabled == false)
        {
            // Set active
            countdownText.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        // If the difference between the level platform number and the actual platform number is 3
        if ((GameManager.levelThree - CreateFromPool.platNum) == 3 || (GameManager.levelTwo - CreateFromPool.platNum) == 3)
        {
            //print("Seconds to next level: " + seconds);  // Used for testing

            // Set seconds to 3
            seconds = 3;
        }
        // If the difference between the level platform number and the actual platform number is 2
        else if ((GameManager.levelThree - CreateFromPool.platNum) == 2 || (GameManager.levelTwo - CreateFromPool.platNum) == 2)
        {
            //print("Seconds to next level: " + seconds);  // Used for testing

            // Set seconds to 2
            seconds = 2;
        }
        // If the difference between the level platform number and the actual platform number is 1
        else if ((GameManager.levelThree - CreateFromPool.platNum) == 1 || (GameManager.levelTwo - CreateFromPool.platNum) == 1)
        {
            //print("Seconds to next level: " + seconds);  // Used for testing

            // Set seconds to 1
            seconds = 1;
        }
        else
        {
            //print("Seconds to next level: " + seconds);  // Used for testing

            // Set seconds back to 0
            seconds = 0;
        }

        // If seconds is 0
        if (seconds == 0)
        {
            // Deactivate countdownText
            countdownText.gameObject.SetActive(false);
        }
        else // Otherwise
        {
            // Set active
            countdownText.gameObject.SetActive(true);
            // And display the text on screen
            countdownText.text = seconds.ToString();
        }
    } // Update - END
} // Class - END
