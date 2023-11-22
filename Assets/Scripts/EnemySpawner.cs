using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;          // Prefab for the enemy to be spawned
    
    [SerializeField]
    private GameObject upgradePrefab;          

    [SerializeField]
    private float enemySpawnDelay;           // Delay between enemy spawns

    [SerializeField]
    private bool enemySpawnOn = true;        // Toggle for enabling enemy spawning

    [SerializeField]
    private bool enemyWavesOn = true;        // Toggle for enabling enemy waves
    
    [SerializeField]
    private bool CountdownOn = true; 

    private Vector3 randomPositionOnScreen;  // Random position to spawn enemies
    public Rigidbody2D rb;
    private float timeUntilEnemySpawn;       // Countdown timer for enemy spawn
    private float enemiesSpawnCapIncremental;      // Number of enemies to spawn in each level
    private float enemiesSpawned;        // Counter for enemies spawned in the current level
    private int enemiesSpawnedTotal = 0;
    public Room Room;
    public Counters Icons;

    // Start is called before the first frame update
    void Start()
    {
        if (CountdownOn)
        {
            //Countdown.StartCountdown(5f);
            enemySpawnOn = false;
        }
        else
        {
            StartNextLevel();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilEnemySpawn -= Time.deltaTime;
        if (enemySpawnOn)
        {
            SpawnEnemyWaveForLevel();
            
            if (enemiesSpawned >= enemiesSpawnCapIncremental && enemyWavesOn)
            {
                if (enemiesSpawnedTotal <= Icons.enemiesFelledCount)
                {
                    Instantiate(upgradePrefab, transform.position, Quaternion.identity);
                    enemySpawnOn = false;
                }
            }
        }
    }

    // Set a random time delay until the next enemy spawn
    private void TimeUntilNextSpawn()
    {
        timeUntilEnemySpawn = Random.Range((enemySpawnDelay * 0.5f), enemySpawnDelay);
    }

    // Move the spawner to a random position on the screen
    void MoveToRandomPosition()
    {
        float x = Random.Range(-5f, 6.9f);
        float y = Random.Range(-3.6f, 2.85f);

        randomPositionOnScreen = new Vector3(x, y, transform.position.z);
        rb.MovePosition(randomPositionOnScreen);
    }

    // Spawn a single enemy
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemiesSpawned++;
        enemiesSpawnedTotal++;
        TimeUntilNextSpawn();
        MoveToRandomPosition();
    }

    // Spawn an enemy wave for the current level
    public void SpawnEnemyWaveForLevel()
    {
        if (timeUntilEnemySpawn <= 0)
        {
            if (enemiesSpawned <= enemiesSpawnCapIncremental)
            {
                SpawnEnemy();
            }
        }
    }

    // Start the next level by resetting counters and spawning the first wave
    public void StartNextLevel()
    {
        enemySpawnOn = true;
        Room.IncrementRoomCount();
        enemiesSpawnCapIncremental = Room.enemiesSpawnCap * (Room.rooms * 1.1f);
        enemiesSpawned = 0;
        SpawnEnemyWaveForLevel();
    }
}
