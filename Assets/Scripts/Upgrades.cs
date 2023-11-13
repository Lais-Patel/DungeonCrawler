using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Basic object to store basic data of each type of Upgrade
public class UpgradeItem
{
    public string upgradeName { get; set; }
    public float upgradeTier { get; set; }
    public string upgradeValue1 { get; set; }
    public string upgradeValue2 { get; set; }
}

public class Upgrades : MonoBehaviour
{
	[SerializeField]
	private Player Player;

    // Add upgrades to the player's inventory
    public void addUpgradeToInventory(int numberUpgradeToAdd)
    {
        int i = (3 * numberUpgradeToAdd) - 2;
        string[] lines = File.ReadAllLines("Assets/Upgrades/upgradeInventoryIndex.txt");
        UpgradeItem upgrade = new UpgradeItem
        {
            upgradeName = lines[i],
            upgradeTier = 1f,
            upgradeValue1 = lines[i + 1],
            upgradeValue2 = lines[i + 2]
        };
		Debug.Log("upgradeName  -  " + upgrade.upgradeName);
		Debug.Log("upgradeTier  -  " + upgrade.upgradeTier);
		Debug.Log("upgradeValue1  -  " + upgrade.upgradeValue1);
		Debug.Log("upgradeValue2  -  " + upgrade.upgradeValue2);
        Player.upgradeInventory.Add(upgrade);
    }
}
