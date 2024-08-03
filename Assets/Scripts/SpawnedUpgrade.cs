using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnedUpgrade : MonoBehaviour
{
    public int numberOfTheUpgrade;  // Stores the value of the upgrade
    public Sprite UpgradeIcon0;     // Reference to the Image Icon of the Upgrade
    public Sprite UpgradeIcon1;     // Reference to the Image Icon of the Upgrade
    public Sprite UpgradeIcon2;     // Reference to the Image Icon of the Upgrade
    public Sprite UpgradeIcon3;     // Reference to the Image Icon of the Upgrade
    public Sprite UpgradeIcon4;     // Reference to the Image Icon of the Upgrade
    public Sprite UpgradeIcon5;     // Reference to the Image Icon of the Upgrade
    private SpriteRenderer Renderer;      // Reference to the Renderer of the upgrade
    private Color colour;           // Reference to the Colour component of the upgrade

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of the upgrade randomly from 0 to 5
        numberOfTheUpgrade = Random.Range(0, 6);
        
        Renderer = GetComponent<SpriteRenderer>();
        // Applies colour based on the value
        if (numberOfTheUpgrade == 0)
        {
            Renderer.sprite = UpgradeIcon0;
        }
        else if (numberOfTheUpgrade == 1)
        {
            Renderer.sprite = UpgradeIcon1;
        }
        else if (numberOfTheUpgrade == 2)
        {
            Renderer.sprite = UpgradeIcon2;
        }
        else if (numberOfTheUpgrade == 3)
        {
            Renderer.sprite = UpgradeIcon3;
        }
        else if (numberOfTheUpgrade == 4)
        {
            Renderer.sprite = UpgradeIcon4;
        }
        else if (numberOfTheUpgrade == 5)
        {
            Renderer.sprite = UpgradeIcon5;
        }
    }
}
