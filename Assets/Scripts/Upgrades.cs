using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Upgrades : MonoBehaviour
{
	[SerializeField]
	private Player Player;

	public static object[,] upgradeShop = 
	{
		{"Damage UP", 0, 10f}, 
		{"Max Health UP", 0, 10f}, 
		{"Defence UP", 0, 10f}, 
		{"Speed UP", 0, 10f}	
	};

    // Add upgrades to the player's inventory
	public void addUpgradeToInventory(int numberUpgradeToAdd)
	{
		Debug.Log(upgradeShop[numberUpgradeToAdd, 1]);
		upgradeShop[numberUpgradeToAdd, 1] = (int)upgradeShop[numberUpgradeToAdd, 1] + 1;
		Debug.Log(upgradeShop[numberUpgradeToAdd, 1]);
		//upgradeLogic(upgradeShop[numberUpgradeToAdd,0]);
	}
	
	private void upgradeLogic(string upgradeEffect)
	{
		if (upgradeShop[1,0] == upgradeEffect)
		{
			Player.health *= 1.1;
		}
	}
}
