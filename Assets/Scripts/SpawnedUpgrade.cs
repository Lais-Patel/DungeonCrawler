using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnedUpgrade : MonoBehaviour
{
    public int numberOfTheUpgrade;  // Stores the value of the upgrade
    public Sprite[] UpgradeIcons;     // Reference to the Image Icon of the Upgrade
    private SpriteRenderer Renderer;      // Reference to the Renderer of the upgrade
    private Color colour;           // Reference to the Colour component of the upgrade

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of the upgrade randomly from 0 to 5
        numberOfTheUpgrade = Random.Range(0, 6);
        
        Renderer = GetComponent<SpriteRenderer>();
        // Applies colour based on the value
        if (numberOfTheUpgrade >= 0 && numberOfTheUpgrade < UpgradeIcons.Length)
        {
            Renderer.sprite = UpgradeIcons[numberOfTheUpgrade];
        }
    }
}
