using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnedUpgrade : MonoBehaviour
{
    public int numberOfTheUpgrade;  // Stores the value of the upgrade
    public Sprite[] upgradeIcons;     // Reference to the Image Icon of the Upgrade
    private SpriteRenderer Renderer;      // Reference to the Renderer of the upgrade
    private List<int> possibleChoices = new List<int> {0, 1, 2, 3, 4, 5};

    private void Awake()
    {
        numberOfTheUpgrade = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] upgradesToCheck = GameObject.FindGameObjectsWithTag("SpawnedUpgrade");
        foreach (GameObject upgradeOnScreen in upgradesToCheck)
        {
            SpawnedUpgrade spawnedUpgrades = upgradeOnScreen.GetComponent<SpawnedUpgrade>();
            possibleChoices.Remove(spawnedUpgrades.numberOfTheUpgrade);
        }
        numberOfTheUpgrade = possibleChoices[Random.Range(0, possibleChoices.Count)];
        
        Renderer = GetComponent<SpriteRenderer>();
        
        if (numberOfTheUpgrade >= 0 && numberOfTheUpgrade < upgradeIcons.Length)
        {
            Renderer.sprite = upgradeIcons[numberOfTheUpgrade];
        }
    }
}
