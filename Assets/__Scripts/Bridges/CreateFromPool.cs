using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFromPool : MonoBehaviour
{
    // == Public Fields ==
    public static GameObject phantomPlayer;
    public static GameObject lastPlatform;
    public static int platNum = 0;

    private void Awake()
    {
        // Create a Phantom
        phantomPlayer = new GameObject("phantom");
    } // Awake - END

    public static void RunPhantom()
    {
        GameObject p = Pool.singleton.GetRandomPlatform();

        // Pool is Empty
        if (p == null) return;

        // If there is no previous platform
        if (lastPlatform != null)
        {
            // Increase Counter (Number of Created Platforms)
            platNum++;
            //print("Plat Num: " + platNum); // Used for testing

            // Set the phantoms position to last platforms position + 10.0f (platforms length) further than the player
            phantomPlayer.transform.position = lastPlatform.transform.position + PlayerBehaviour.player.transform.forward * 10.0f;

            // If the previous platform was one of those (Set to the right positions)
            if (lastPlatform.tag == "BridgeDown")
            {
                phantomPlayer.transform.Translate(0, -1.35f, 4.8f);
            }
            else if (lastPlatform.tag == "BridgeUp")
            {
                phantomPlayer.transform.Translate(0, 0, -5.0f);
            }
            else if (lastPlatform.tag == "BridgeArchDefault")
            {
                phantomPlayer.transform.Translate(0, -1.55f, 1.9f);
            }
            else if (lastPlatform.tag == "BridgeArchMiddle")
            {
                phantomPlayer.transform.Translate(0, -7.4f, 0);
            }
        } // if (lastPlatform != null) - END

        // Set last platform to p
        lastPlatform = p;
        // Enable the platform
        p.SetActive(true);
        // Transform the platform to Phantoms Position and Rotation
        p.transform.position = phantomPlayer.transform.position;
        p.transform.rotation = phantomPlayer.transform.rotation;

        // If these platforms are first (Set them to the right positions)
        if (p.tag == "BridgeDown")
        {
            p.transform.position += new Vector3(0, 0, -5.0f);
        }
        else if (p.tag == "BridgeUp")
        {
            p.transform.Rotate(0, 180, 0);
            p.transform.position += new Vector3(0, 1.35f, 4.8f);
        }
        else if (p.tag == "BridgeArchDefault")
        {
            p.transform.position += new Vector3(0, 1.55f, 2f);
        }
        else if (p.tag == "BridgeArchMiddle")
        {
            p.transform.position += new Vector3(0, 1.4f, 0);
        }
    } // RunPhantom - END
} // Class - END
