using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public Player Player; // Reference to the associated player
	public Upgrades Upgrades;

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Melee Hitbox"))
        {
            // When attacked by an enemy, calculate and apply damage to the player
            Enemy Enemy = other.GetComponentInParent<Enemy>();
            if (!Enemy.currentlySpawning)
            {
                float damageDealt = Enemy.calculateDamageDealt();
                Player.enemyMeleeAttack(damageDealt);
            }
        }

        if (other.CompareTag("SpawnedUpgrade"))
        {
			SpawnedUpgrade SpawnedUpgrade = other.gameObject.GetComponent<SpawnedUpgrade>();
            Upgrades.addUpgradeToInventory(SpawnedUpgrade.numberOfTheUpgrade);
			SpawnedUpgrade.Die();
        }
    }
}
