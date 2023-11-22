using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public Enemy Enemy; // Reference to the associated enemy

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the Enemy script in the scene
        Enemy = FindObjectOfType<Enemy>();
    }

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullets") && !Enemy.currentlySpawning)
        {
            Debug.Log("HIT");
            Bullet Bullet = other.gameObject.GetComponent<Bullet>();
            // If the entering collider has the "Bullets" tag, inform the associated enemy to take damage
            if (!Bullet.hitEnemy)
            {
                Bullet.hitEnemy = true;
                Enemy.TakeDamage();
            }
        }
    }
}
