using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyHitbox : MonoBehaviour
{
    public Enemy Enemy; // Reference to the associated enemy
    private bool canAttack = true;
    private float attackDelay = 1f;
    public PlayerHitbox PlayerHitbox;
    private Collider2D enemyMeleeCollider;
    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the Enemy script in the scene
        Enemy = FindObjectOfType<Enemy>();
        PlayerHitbox = FindObjectOfType<PlayerHitbox>();
        enemyMeleeCollider = GetComponent<Collider2D>();
        playerCollider = PlayerHitbox.GetComponent<Collider2D>();
    }
    
    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        if (canAttack && enemyMeleeCollider.IsTouching(playerCollider) && !Player.hasPressedDash)
        {
            StartCoroutine(AttackCooldown());

        }
    }

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullets") && !Enemy.currentlySpawning)
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            // If the entering collider has the "Bullets" tag, inform the associated enemy to take damage
            if (!bullet.hitEnemy)
            {
                bullet.hitEnemy = true;
                Enemy.TakeDamage();
            }
        }
    }
    
    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        PlayerHitbox.EnemyMeleeAttack(Enemy.CalculateDamageDealt());
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
