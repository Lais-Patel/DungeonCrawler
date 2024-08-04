using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public Player Player;        // Reference to the Player
	public Upgrades Upgrades;    // Reference to the Upgrades Script
    public Countdown Countdown;  // Reference to the Countdown Script

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnedUpgrade"))
        {   // When the player picks up an upgrade it pulls the type of the upgrade 
			SpawnedUpgrade SpawnedUpgrade = other.gameObject.GetComponent<SpawnedUpgrade>();
            Upgrades.addUpgradeToInventory(SpawnedUpgrade.numberOfTheUpgrade);
            
            // Starts a countdown until the next wave of enemies starts
            Countdown.StartCountdown(5f);
            
            // Ensures other upgrades on the screen are removed
            GameObject[] upgradesToDestroy = GameObject.FindGameObjectsWithTag("SpawnedUpgrade");
            foreach (GameObject upgradeOnScreen in upgradesToDestroy)
            {
                Destroy(upgradeOnScreen);
            }
        }
    }

    public void enemyMeleeAttack(float damageDealt)
    {
        Player.enemyMeleeAttack(damageDealt);
    }
}
