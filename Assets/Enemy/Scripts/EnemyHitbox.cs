using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public Enemy Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Melee Hitbox"))
        {
            //meleeAttack();
        }
        else if (other.CompareTag("Bullets"))
        {
            Enemy.TakeDamage();
        }
    }
}
