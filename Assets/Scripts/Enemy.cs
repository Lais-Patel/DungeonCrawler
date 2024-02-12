using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Enemy : Entity
{
    public Transform player;                          // Reference to Players Position
    private Renderer Renderer;      // Reference to the Renderer of the upgrade
    private float difficultyScore;                    // Difficulty of the game
    public Counters Icons;                            // Reference to the Counters Script
    public Room Room;                                 // Reference to the Room Script
    private float spawnDelay = 1;                     // Time it takes for Enemy to spawn in
    public bool currentlySpawning;                    // If the enemy is currently spawning in
    [SerializeField] new private float health;        // Holds the health of the enemy
    new private float attackPower;                    // Holds the attack of the enemy
    private float maxSpeed;
    private float temp_speed;

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning animation wait
        StartCoroutine(SpawningAnimationWait());

        // Get a reference to the player's Transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Find references to Counters and Room scripts in the scene
        Icons = FindObjectOfType<Counters>();
        Room = FindObjectOfType<Room>();

        // Set initial values for enemy properties
        maxSpeed = 2f;
        temp_speed = maxSpeed;
        acceleration = 0.0333f;
        difficultyScore = Room.rooms;
        health = 20f * (1f + difficultyScore * 0.1f);
        defence = 0f;
        attackPower = 2f * (1f + difficultyScore * 0.1f);
        Renderer = GetComponent<Renderer>();
    }

    // Coroutine to handle enemy spawning animation delay
    private IEnumerator SpawningAnimationWait()
    {
        currentlySpawning = true;
        yield return new WaitForSeconds(spawnDelay);
        currentlySpawning = false;
    }
    private IEnumerator damageSlowDown()
    {
        Renderer.material.color = Color.red;
        temp_speed = maxSpeed;
        maxSpeed *= 0.5f;
        yield return new WaitForSeconds(0.5f);
        Renderer.material.color = Color.white;
        maxSpeed = temp_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlySpawning)
        {
            return; // Do nothing during spawning animation
        }
        else
        {
            // Finds the direction that the enemy is moving in
            directionMovement = player.transform.position - transform.position;
            
            // Sets animation parameters to play the correct animation cycle
            animationController.SetFloat("Vertical", directionMovement.y);
            animationController.SetFloat("Horizontal", directionMovement.x);
            animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);
        }
    }

    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        if (currentlySpawning)
        {
            return; // Do nothing during spawning animation
        }
        else
        {
            // Set the enemy's velocity for movement
            velocity = maxSpeed;
            transform.position = Vector2.MoveTowards(this.transform.position, (player.transform.position), velocity * Time.fixedDeltaTime);
            EntityMovementCalc();
        }
    }

    // Calculate the damage dealt by the enemy
    public float calculateDamageDealt()
    {
        damageDealt = attackPower;
        return damageDealt;
    }

    // Handle enemy taking damage
    public void TakeDamage()
    {
        health -= calculateDamageTaken(defence, Player.calculateDamageDealt());
        StartCoroutine(damageSlowDown());
        
        if (health <= 0)
        {
            // Increment the count of defeated enemies and destroy this enemy object
            Icons.IncrementEnemeyFelledCount();
            Destroy(gameObject);
        }
    }
}