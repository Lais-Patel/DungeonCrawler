using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public Enemy Enemy; // Reference to the associated enemy
    private bool canAttack = true;
    private float attackDelay = 1f;
    private PlayerHitbox PlayerHitbox;
    private Collider2D enemyMeleeHitbox;
    private Collider2D playerHitbox;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the Enemy script in the scene
        Enemy = FindObjectOfType<Enemy>();
        PlayerHitbox = FindObjectOfType<PlayerHitbox>();
        enemyMeleeHitbox = GetComponent<Collider2D>();
        playerHitbox = PlayerHitbox.GetComponent<Collider2D>();
    }
    
    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        if (canAttack && enemyMeleeHitbox.IsTouching(playerHitbox) && !Player.hasPressedDash)
        {
            StartCoroutine(attackCooldown());

        }
    }

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullets") && !Enemy.currentlySpawning)
        {
            Bullet Bullet = other.gameObject.GetComponent<Bullet>();
            // If the entering collider has the "Bullets" tag, inform the associated enemy to take damage
            if (!Bullet.hitEnemy)
            {
                Bullet.hitEnemy = true;
                Enemy.TakeDamage();
            }
        }
    }
    
    private IEnumerator attackCooldown()
    {
        canAttack = false;
        PlayerHitbox.enemyMeleeAttack(Enemy.calculateDamageDealt());
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
