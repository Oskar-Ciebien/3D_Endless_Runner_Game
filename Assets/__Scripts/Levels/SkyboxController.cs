using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    // == Public Fields ==
    public Material skyboxLevel1;
    public Material skyboxLevel2;
    public Material skyboxLevel3;
    // public Material platformMaterialLevel1;
    // public Material platformMaterialLevel2;  // I tried to change the platforms on each level also.
    // public Material platformMaterialLevel3;  // But it did not work out for me

    // == Private Fields ==
    private List<GameObject> platforms;

    void Update()
    {
        // If the amount of platforms is greater than level three platforms
        if (CreateFromPool.platNum >= GameManager.levelThree)
        {
            // Render skybox for level 3
            RenderSettings.skybox = skyboxLevel3;
            //platforms.material = platformMaterialLevel1;
        }
        // If the amount of platforms is greater than level two platforms
        else if (CreateFromPool.platNum >= GameManager.levelTwo)
        {
            // Render skybox for level 2
            RenderSettings.skybox = skyboxLevel2;
        }
        else // Otherwise on Level 1
        {
            // Render skybox for level 1
            RenderSettings.skybox = skyboxLevel1;
        }
    }
} // Class - END
