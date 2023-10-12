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

    // Update is called once per frame
    void Update()
    {
        // This method is currently empty as no updates are needed here
    }

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullets") && !Enemy.currentlySpawning)
        {
            // If the entering collider has the "Bullets" tag, inform the associated enemy to take damage
            Enemy.TakeDamage();
        }
    }
}
