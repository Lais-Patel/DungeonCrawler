using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Random = UnityEngine.Random;

public class Enemy : Entity
{
    public Transform Player;                          // Reference to Players Position
    public Renderer Renderer;                        // Reference to the Renderer of the upgrade
    public float difficultyScore;                     // Difficulty of the game
    public Counters Counters;                         // Reference to the Counters Script
    public Room Room;                                 // Reference to the Room Script
    private float spawnDelay = 1;                     // Time it takes for Enemy to spawn in
    public bool currentlySpawning;                    // If the enemy is currently spawning in
    [SerializeField] public new float health;        // Holds the health of the enemy
    public new float attackPower;                    // Holds the attack of the enemy
    public new float maxSpeed;
    public float tempSpeed;

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
        health = 20f * (1f + difficultyScore * 0.1f);
        defence = 0f;
        attackPower = 2f * (1f + difficultyScore * 0.1f);
        Renderer = GetComponent<Renderer>();
    }

    // Coroutine to handle enemy spawning animation delay
    public IEnumerator SpawningAnimationWait()
    {
        currentlySpawning = true;
        yield return new WaitForSeconds(spawnDelay);
        currentlySpawning = false;
    }
    private IEnumerator DamageSlowDown()
    {
        Renderer.material.color = Color.red;
        tempSpeed = maxSpeed;
        maxSpeed *= 0.5f;
        yield return new WaitForSeconds(0.5f);
        Renderer.material.color = Color.white;
        maxSpeed = tempSpeed;
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

    // Calculate the damage dealt by the enemy
    public float CalculateDamageDealt()
    {
        damageDealt = attackPower;
        return damageDealt;
    }

    // Handle enemy taking damage
    public void TakeDamage()
    {
        health -= CalculateDamageTaken(defence, global::Player.CalculateDamageDealt());
        StartCoroutine(DamageSlowDown());
        
        if (health <= 0)
        {
            // Increment the count of defeated enemies and destroy this enemy object
            Counters.IncrementEnemeyFelledCount();
            Destroy(gameObject);
        }
    }
}