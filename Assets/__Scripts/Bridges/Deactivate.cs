using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Deactivate : MonoBehaviour
{
    // == Private Fields ==
    private bool deactivateScheduled = false;
    private float secondsAfterCollision = 4.0f;

    private void OnTriggerExit(Collider other)
    {
        // If the player collides with the collider and the deactivateScheduled is false
        if ((other.gameObject.tag == "Player") && (deactivateScheduled == false))
        {
            // Calls SetPlatformInactive after secondsAfterCollision
            Invoke("SetPlatformInactive", secondsAfterCollision);
            // Sets deactivateScheduled to true so that this if statement is not triggered again
            deactivateScheduled = true;
        }
    }

    private void SetPlatformInactive()
    {
        // Disables the collided platform
        this.gameObject.SetActive(false);
        // Sets deactivateScheduled to false
        deactivateScheduled = false;
    }
} // Class - END
