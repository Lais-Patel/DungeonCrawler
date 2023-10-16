using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Enemy : Entity
{
    public Transform player;
    public float distanceFromPlayer;
    private float difficultyScore;
    public Counters Icons;
    public Room Room;
    private float spawnDelay = 1;
    public bool currentlySpawning;
    
    new private float health;
    new private float attackPower;
    
    private float closestDistance = float.MaxValue;
    private Enemy closestEnemy = null;
    private Vector3 positionClosestEnemy;

    private Vector3 targetPosition;

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
        acceleration = 0.0333f;
        health = 20f;
        defence = 0f;
        attackPower = 2f * (1f + difficultyScore * 0.1f);
        difficultyScore = Room.rooms;
    }

    // Coroutine to handle enemy spawning animation delay
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
            return; // Do nothing during spawning animation
        }
        else
        {
            // Calculate distance from the enemy to the player
            distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
            directionMovement = player.transform.position - transform.position;
            
            FindClosestEnemy();
            CalculateTargetPosition();
            //directionToClosestEnemy = closestEnemy.transform.position - transform.position;
            
            // Set animation parameters
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
            Debug.Log("Player Transform: " + player.transform.position );
            Debug.Log("positionClosestEnemy: " + positionClosestEnemy );
            Debug.Log("targetPosition: " + (player.transform.position + (positionClosestEnemy)) );
            transform.position = Vector2.MoveTowards(this.transform.position, (targetPosition), maxSpeed * Time.fixedDeltaTime);
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
        
        if (health == 0)
        {
            // Increment the count of defeated enemies and destroy this enemy object
            Icons.IncrementEnemeyFelledCount();
            Destroy(gameObject);
        }
    }

	private void FindClosestEnemy()
	{
		List<Enemy> enemiesOnScreen = new List<Enemy>();
        enemiesOnScreen.AddRange(FindObjectsOfType<Enemy>());

        foreach (Enemy enemy in enemiesOnScreen)
        {
            if (enemy != this)
            {
                float distanceFromEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceFromEnemy < closestDistance)
                {
                    Debug.Log(closestEnemy);
                    closestDistance = distanceFromEnemy;
                    closestEnemy = enemy;
                }
            }
        }

        if (closestEnemy == null)
        {
            positionClosestEnemy = Vector2.zero;
            //Debug.Log("null - positionClosestEnemy: " + positionClosestEnemy);
        }
        else
        {
            positionClosestEnemy = closestEnemy.transform.position;
            //Debug.Log("!null - positionClosestEnemy: " + positionClosestEnemy);
        }
    } 
    
    private void CalculateTargetPosition()
    {
        float weight  = 1f / closestDistance;
        Vector2 selfToClosetEnemy = Vector2.zero;
        
        if (closestEnemy != null)
        {
            selfToClosetEnemy = positionClosestEnemy - this.transform.position;
        }
        
        Vector2 selfToPlayer = player.transform.position - this.transform.position;
        targetPosition = (2f * selfToPlayer) - (weight * selfToClosetEnemy);
    }
}