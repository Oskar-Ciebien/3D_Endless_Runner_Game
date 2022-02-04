using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // MeshRenderer
    MeshRenderer[] meshRenderers;

    // == Public Fields ==
    public AudioClip pickupSound;

    // == Private Fields ==
    private int livesLeft; // Read from the PlayerPrefs

    private void Start()
    {
        // Get the mesh renderers at the start ( one get called )
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
        //print("LivesLeft " + livesLeft); // Used for testing
        //print("Prefs " + PlayerPrefs.GetInt("LivesLeft")); // Used for testing
    }

    private void OnTriggerEnter(Collider other)
    {
        // If collide with Player
        if (other.gameObject.tag == "Player")
        {
            // Get LivesLeft from PlayerPrefs
            livesLeft = PlayerPrefs.GetInt("LivesLeft");

            // If player has 1 or 2 lives left
            if (livesLeft > 0 && livesLeft < 3)
            {
                // Add one life
                livesLeft++;
                // Set it back to player prefs
                PlayerPrefs.SetInt("LivesLeft", livesLeft);
            }

            //print("LivesLeft " + livesLeft); // Used for Testing
            //print("Prefs " + PlayerPrefs.GetInt("LivesLeft")); // Used for Testing

            // Disable the mesh renderers on the hats
            foreach (MeshRenderer m in meshRenderers)
            {
                m.enabled = false;
            }

            // Play pickup sound effect
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
    } // OnTriggerEnter - END

    private void OnEnable()
    {
        // Re-enable the mesh renderers on the hats
        if (meshRenderers != null)
        {
            foreach (MeshRenderer m in meshRenderers)
            {
                m.enabled = true;
            }
        }
    } // OnEnable - END
}
