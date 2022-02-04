using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    // == Private Fields ==
    private float speed = -0.1f;

    private void FixedUpdate()
    {
        //print("SpeedCheck-1 " + speed); // Used for testing

        // If the player is dead
        if (PlayerBehaviour.isDead) return;

        // Level 3 - Increase Speed from GameManager Variables
        if (CreateFromPool.platNum >= GameManager.levelThree)
        {
            speed = GameManager.speedLevelThree;
            PlayerBehaviour.moveSpeed = GameManager.playerSpeedLevelThree;
        }
        // Level 2 - Increase Speed from GameManager Variables
        else if (CreateFromPool.platNum >= GameManager.levelTwo)
        {
            speed = GameManager.speedLevelTwo;
            PlayerBehaviour.moveSpeed = GameManager.playerSpeedLevelTwo;
        }
        // Level 1 - Increase Speed from GameManager Variables
        else
        {
            speed = GameManager.speedLevelOne;
            PlayerBehaviour.moveSpeed = GameManager.playerSpeedLevelOne;
        }

        // Move the platforms
        this.transform.position += PlayerBehaviour.player.transform.forward * speed;
    } // FixedUpdate - END
} // Class - END
