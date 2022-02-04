using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyPickup : MonoBehaviour
{
    // MeshRenderer
    MeshRenderer[] meshRenderers;

    // == Public Fields ==
    public AudioClip pickupSound;

    private void Start()
    {
        // Get the mesh renderers at the start ( one get called )
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // If collide with Player
        if (other.gameObject.tag == "Player")
        {
            // Update the Score in GameData
            GameData.singleton.UpdateScore(1);

            // Disable the mesh renderers on the Trophies
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
        // Re-enable the mesh renderers on the Trophies
        if (meshRenderers != null)
        {
            foreach (MeshRenderer m in meshRenderers)
            {
                m.enabled = true;
            }
        }
    } // OnEnable - END
} // Class - END
