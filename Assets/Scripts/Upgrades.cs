using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Serialization;

public class Upgrades : MonoBehaviour
{
	[SerializeField] private Player Player;      // Reference to the Player Script
	[SerializeField] private Counters Counters;  // Reference to the Counters Script
	[SerializeField] private Gun Gun;            // Reference to the Gun Script

	public static object[,] upgradeShop =        // Stores the multipliers of the upgrades
	{
		{"Damage UP", 0, 1.5f},     // Dark red
		{"Max Health UP", 0, 1.1f}, // Light Red
		{"Defence UP", 0, 1.5f},    // Pale Blue
		{"Speed UP", 0, 1.25f},     // Green
		{"Fire Speed UP", 0, 0.85f},  // Orange
		{"Health Regain", 0, 0.3f}  // Yellow
	};

    // Add upgrades to the player's inventory
	public void AddUpgradeToInventory(int numberUpgradeToAdd)
	{
		upgradeShop[numberUpgradeToAdd, 1] = (int)upgradeShop[numberUpgradeToAdd, 1] + 1;
		UpgradeLogic((string)upgradeShop[numberUpgradeToAdd,0]);
	}
	
	// Applies the changes that the gained upgrade gives
	private void UpgradeLogic(string upgradeEffect)
	{
		if (upgradeShop[0,0] == upgradeEffect)
		{
			Player.attackPower *= (float)upgradeShop[0,2];
		}
		else if (upgradeShop[1,0] == upgradeEffect)
		{
			Counters.UpgradeHealth((float)upgradeShop[1,2]);
			Player.health += Counters.SliderHealthBar.maxValue * (float)upgradeShop[1,2] - Counters.SliderHealthBar.maxValue;
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
		else if (upgradeShop[4,0] == upgradeEffect)
		{
			Gun.delayFire *= (float)upgradeShop[4,2];
		}
		else if (upgradeShop[5,0] == upgradeEffect)
		{
			if ((Player.health + Counters.SliderHealthBar.maxValue * (float)upgradeShop[5, 2]) > Counters.SliderHealthBar.maxValue)
			{
				Player.health = Counters.SliderHealthBar.maxValue;
			}
			else
			{
				Player.health += Counters.SliderHealthBar.maxValue * (float)upgradeShop[5,2];
			}
			Counters.SetHealth(Player.health);
		}
	}
}
