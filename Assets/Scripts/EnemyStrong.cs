using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrong : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        // Start spawning animation wait
        StartCoroutine(SpawningAnimationWait());

        // Find references to Counters and Room scripts in the scene
        Counters = FindObjectOfType<Counters>();
        Room = FindObjectOfType<Room>();
        
        // Get a reference to the player's Transform
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set initial values for enemy properties
        maxSpeed = Random.Range(1.7f,2.3f);
        tempSpeed = maxSpeed;
        acceleration = 0.0333f;
        difficultyScore = Room.rooms;
        health = 10f * (1f + difficultyScore * 0.1f);
        defence = 0f;
        attackPower = 4f * (1f + difficultyScore * 0.1f);
        Renderer = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!currentlySpawning)
        {
            // Finds the direction that the enemy is moving in
            directionMovement = Player.transform.position - transform.position;
            
            // Sets animation parameters to play the correct animation cycle
            AnimationController.SetFloat("Vertical", directionMovement.y);
            AnimationController.SetFloat("Horizontal", directionMovement.x);
            AnimationController.SetFloat("Velocity", directionMovement.sqrMagnitude);
        }
    }

    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        if (!currentlySpawning)
        {
            // Set the enemy's velocity for movement
            velocity = maxSpeed;
            transform.position = Vector2.MoveTowards(this.transform.position, (Player.transform.position), velocity * Time.fixedDeltaTime);
            EntityMovementCalc();
        }
    }
}
