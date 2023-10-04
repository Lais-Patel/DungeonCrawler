using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform player; 
    public float distanceFromPlayer;
    private float difficultyRating;
    public Counters Icons;
    public Room Room;

    //constructor
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Icons = FindObjectOfType<Counters>();
        maxSpeed = 2f;
        acceleration = 0.0333f;
        health = 3f;
        defence = 1f;
        difficultyRating = Room.rooms;
    }


    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionMovement = player.transform.position - transform.position;

        animationController.SetFloat("Vertical", directionMovement.y);
        animationController.SetFloat("Horizontal", directionMovement.x);
        animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        velocity = maxSpeed;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, maxSpeed * Time.fixedDeltaTime);
        EntityMovementCalc();      
    }

    public float calculateDamageDealt(float attackPower, float difficultyRating)
    {
        damageDealt = attackPower;
        return damageDealt;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Melee Hitbox"))
        {
            //meleeAttack();
        }
        else if (other.CompareTag("Bullets"))
        {
            health -= 1;
            if (health == 0)
            {
                Icons.IncrementEnemeyFelledCount();
                Destroy(gameObject);
            }
        }
    }
}
