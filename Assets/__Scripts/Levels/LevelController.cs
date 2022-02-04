using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // == Public Fields ==
    public Text levelText;

    // == Private Fields ==
    private string level;

    void Update()
    {
        // On Level 3
        if (CreateFromPool.platNum >= GameManager.levelThree)
        {
            level = "Level 3";
        }
        // On Level 2
        else if (CreateFromPool.platNum >= GameManager.levelTwo)
        {
            level = "Level 2";
        }
        else // On Level 1
        {
            level = "Level 1";
        }

        // Display on the Screen
        levelText.text = level.ToString();
    }
}
