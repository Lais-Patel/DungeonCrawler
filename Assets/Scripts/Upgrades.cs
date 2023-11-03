using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic object to store basic data of each type of Upgrade
class UpgradeItem
{
    public string upgradeName { get; set; }
    public float upgradeTier { get; set; }
    public float upgradeValue1 { get; set; }
    public float upgradeValue2 { get; set; }
}

public class Upgrades : MonoBehaviour
{
    // Add upgrades to the player's inventory
    public void addUpgradeToInventory(int numberUpgradeToAdd)
    {
        int i = (3 * numberUpgradeToAdd) - 2;
        string[] lines = File.ReadAllLines("upgradeInventoryIndex.txt");
        UpgradeItem upgrade = new UpgradeItem
        {
            upgradeName = lines[i],
            upgradeTier = 1f,
            upgradeValue1 = float.Parse(lines[i + 1]),
            upgradeValue2 = float.Parse(lines[i + 2])
        };
        Player.upgradeInventory.Add(upgrade);
    }
}
