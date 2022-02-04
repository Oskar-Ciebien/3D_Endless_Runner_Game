using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Shown in the Inspector
public class PoolItem
{
    public GameObject Prefab;
    public int Amount;
    public bool IsExpandable;
}

public class Pool : MonoBehaviour
{
    // == Public Fields ==
    public List<PoolItem> prefabItems; // Definied in the Inspector
    public List<GameObject> poolItemsToUse; // The Object Pool
    public static Pool singleton;

    private void Awake()
    {
        // Set a Singleton
        singleton = this;
        // Create a list of the Objects
        poolItemsToUse = new List<GameObject>();

        // Loop to create the prefab based items
        foreach (PoolItem PI in prefabItems)
        {
            for (int i = 0; i < PI.Amount; i++)
            {
                GameObject GO = Instantiate(PI.Prefab);
                GO.SetActive(false); // Not Visible until needed
                poolItemsToUse.Add(GO);
            }
        }
    }

    public GameObject GetRandomPlatform()
    {
        // Shuffle the list poolItemsToUse
        Utils.Shuffle(poolItemsToUse);

        // Go through the poolItemsToUse
        for (int i = 0; i < poolItemsToUse.Count; i++)
        {
            // If the item is not active in the hierarchy
            if (!poolItemsToUse[i].activeInHierarchy)
            {
                // Return it
                return poolItemsToUse[i];
            }
        }
        // No more available platforms
        foreach (PoolItem PI in prefabItems)
        {
            // If platform is expandable
            if (PI.IsExpandable)
            {
                GameObject GO = Instantiate(PI.Prefab);
                GO.SetActive(false); // Not Visible until needed
                poolItemsToUse.Add(GO);
                // Add it to the pool
                return GO;
            }
        }
        // Nothing else left
        return null;
    }
} // Pool Class - END

// Randomise the list using the Fisher Yeats Shuffle
public static class Utils
{
    // == Public Fields ==
    public static System.Random r = new System.Random();

    // Shuffle
    public static void Shuffle<T>(this IList<T> list)
    {
        // Using the Fisher Yeats Algorithm
        int n = list.Count;

        while (n > 1)
        {
            // Decrease n
            n--;

            int k = r.Next(n + 1); // Avoid 0 first

            // Shuffle
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
} // Utils Class - END