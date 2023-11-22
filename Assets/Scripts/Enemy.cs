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

    [SerializeField]
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
        difficultyScore = Room.rooms;
        attackPower = 2f * (1f + difficultyScore * 0.1f);
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
            targetPosition = player.transform.position;
            distanceFromPlayer = Vector2.Distance(transform.position, targetPosition);
            directionMovement = targetPosition - transform.position;
            
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
		Debug.Log("HIT");
        
        if (health <= 0)
        {
			Debug.Log("KILL");
            // Increment the count of defeated enemies and destroy this enemy object
            Icons.IncrementEnemeyFelledCount();
            Destroy(gameObject);
        }
    }

	private void FindClosestEnemy()
	{
		List<Enemy> enemiesOnScreen = new List<Enemy>();
        enemiesOnScreen.AddRange(FindObjectsOfType<Enemy>());
        float count = 0;

        foreach (Enemy screenEnemy in enemiesOnScreen)
        {
            count++;
            Debug.Log("Count of Enemies on Screen:    " + count);
            if (screenEnemy != this)
            {
                float distanceFromEnemy = Vector3.Distance(transform.position, screenEnemy.transform.position);

                if (distanceFromEnemy < closestDistance)
                {
                    closestDistance = distanceFromEnemy;
                    closestEnemy = screenEnemy;
                }
            }
        }
    } 
    
    private void CalculateTargetPosition()
    {
        if (Vector3.Distance(transform.position, closestEnemy.transform.position) > 1f)
        {
            targetPosition = player.transform.position;
        }
        else
        {
            targetPosition = player.transform.position - closestEnemy.transform.position;
        }
    }
}