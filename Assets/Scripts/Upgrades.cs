using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Upgrades : MonoBehaviour
{
	[SerializeField]
	private Player Player;

	[SerializeField]
	private Counters Counters;

	public static object[,] upgradeShop = 
	{
		{"Damage UP", 0, 1.1f}, 
		{"Max Health UP", 0, 1.1f}, 
		{"Defence UP", 0, 1.1f}, 
		{"Speed UP", 0, 1.1f}	
	};

    // Add upgrades to the player's inventory
	public void addUpgradeToInventory(int numberUpgradeToAdd)
	{
		Debug.Log(upgradeShop[numberUpgradeToAdd, 1]);
		upgradeShop[numberUpgradeToAdd, 1] = (int)upgradeShop[numberUpgradeToAdd, 1] + 1;
		Debug.Log(upgradeShop[numberUpgradeToAdd, 1]);
		upgradeLogic(upgradeShop[numberUpgradeToAdd,0]);
	}
	
	private void upgradeLogic(string upgradeEffect)
	{
		if (upgradeShop[1,0] == upgradeEffect)
		{
			Debug.Log("	health ");
			Counters.UpgradeHealth((float)upgradeShop[1,2]);
			Player.health *= (float)upgradeShop[1,2];
			Counters.SetHealth(Player.health);
		}
		else if (upgradeShop[2,0] == upgradeEffect)
		{
			Player.defence *= (float)upgradeShop[2,2];
			Counters.SetDefence(Player.defence);
		}
		else if (upgradeShop[3,0] == upgradeEffect)
		{
			Player.maxSpeed *= (float)upgradeShop[3,2];
		}
	}
}
