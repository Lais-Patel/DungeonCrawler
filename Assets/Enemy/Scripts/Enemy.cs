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
    private float spawnDelay = 1;
    private bool currentlySpawning;
    
    //constructor
    void Start()
    {
        StartCoroutine(SpawningAnimationWait());
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Icons = FindObjectOfType<Counters>();
        Room = FindObjectOfType<Room>();
        maxSpeed = 2f;
        acceleration = 0.0333f;
        health = 2f;
        defence = 1f;
        difficultyRating = Room.rooms;
        attackPower = 2 * 1 + difficultyRating/5;
    }

    private IEnumerator SpawningAnimationWait()
    {
        currentlySpawning = true;
        yield return new WaitForSeconds(spawnDelay);
        currentlySpawning = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (currentlySpawning)
        { 
            return;
        }
        else
        {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionMovement = player.transform.position - transform.position;

        animationController.SetFloat("Vertical", directionMovement.y);
        animationController.SetFloat("Horizontal", directionMovement.x);
        animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);
        }
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        if (currentlySpawning)
        { 
            return;
        }
        else
        {
        velocity = maxSpeed;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, maxSpeed * Time.fixedDeltaTime);
        EntityMovementCalc();
        }
    }

    public float calculateDamageDealt()
    {
        damageDealt = attackPower * difficultyRating;
        return damageDealt;
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health == 0)
        {
            Icons.IncrementEnemeyFelledCount();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
