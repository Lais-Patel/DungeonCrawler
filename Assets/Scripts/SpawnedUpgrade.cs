using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnedUpgrade : MonoBehaviour
{
    public int numberOfTheUpgrade;  // Stores the value of the upgrade
    private Renderer Renderer;      // Reference to the Renderer of the upgrade
    private Color colour;           // Reference to the Colour component of the upgrade

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of the upgrade randomly from 1 to 4
        numberOfTheUpgrade = Random.Range(0, 6);
        
        // Applies colour based on the value
        if (numberOfTheUpgrade == 0)
        {
            ColorUtility.TryParseHtmlString("#983944", out colour);
        }
        else if (numberOfTheUpgrade == 1)
        {
            ColorUtility.TryParseHtmlString("#D95763", out colour);
        }
        else if (numberOfTheUpgrade == 2)
        {
            ColorUtility.TryParseHtmlString("#8895AF", out colour);
        }
        else if (numberOfTheUpgrade == 3)
        {
            ColorUtility.TryParseHtmlString("#5DA863", out colour);
        }
        else if (numberOfTheUpgrade == 4)
        {
            ColorUtility.TryParseHtmlString("#F77622", out colour);
        }
        else if (numberOfTheUpgrade == 5)
        {
            ColorUtility.TryParseHtmlString("#FFFF00", out colour);
        }
        
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = colour;
    }
}
