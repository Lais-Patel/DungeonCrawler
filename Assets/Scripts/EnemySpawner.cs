using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab_;      // Prefab for the enemy to be spawned
    [SerializeField] private GameObject _upgradePrefab_;    // Prefab for the upgrades to be spawned  
    [SerializeField] private float maxEnemySpawnDelay;    // Delay between enemy spawns
    [SerializeField] private bool enemySpawnOn = true;    // Toggle for enabling enemy spawning
    [SerializeField] private bool enemyWavesOn = true;    // Toggle for enabling enemy waves
    [SerializeField] private bool countdownOn = true;     // Toggle for enabling the countdown between waves
    private Vector3 randomPositionOnScreen;               // Random position to spawn enemies
    public Rigidbody2D RigidBody;                                // Reference to the rigidbody of the spawner
    private float timeUntilEnemySpawn;                    // Countdown timer for enemy spawn
    private float enemiesSpawnCapIncremental;             // Number of enemies to spawn in each level
    private float enemiesSpawned;                         // Counter for enemies spawned in the current level
    private int enemiesSpawnedTotal = 0;                  // Stores the total amount of enemies spawned during the game
    public Room Room;                                     // Reference to the Room Script
    public Counters Icons;                                // Reference to the Counters Script

    // Start is called before the first frame update
    void Start()
    {
        if (countdownOn)
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
        // Increments timer and checks if another enemy should be spawned
        timeUntilEnemySpawn -= Time.deltaTime;
        if (enemySpawnOn)
        {
            SpawnEnemyWaveForLevel();
            
            // Checks if all the enemies have been spawned and killed
            if (enemiesSpawned >= enemiesSpawnCapIncremental && enemyWavesOn)
            {
                if (GameObject.FindGameObjectsWithTag("Enemies").Length == 0)
                {   // Spawns 3 upgrades in the middle of the screen and turns off enemy spawning
                    Instantiate(_upgradePrefab_, new Vector3(0f, 2f, transform.position.z), Quaternion.identity);
                    Instantiate(_upgradePrefab_, new Vector3(2f, 2f, transform.position.z), Quaternion.identity);
                    Instantiate(_upgradePrefab_, new Vector3(-2f, 2f, transform.position.z), Quaternion.identity);
                    enemySpawnOn = false;
                }
            }
        }
    }

    // Set a random time delay until the next enemy spawn
    private void TimeUntilNextSpawn()
    {
        timeUntilEnemySpawn = Random.Range((maxEnemySpawnDelay * 0.2f), maxEnemySpawnDelay);
    }

    // Move the spawner to a random position on the screen
    void MoveToRandomPosition()
    {
        float x = Random.Range(-7.5f, 7.5f);
        float y = Random.Range(-5f, 2.85f);

        randomPositionOnScreen = new Vector3(x, y, transform.position.z);
        RigidBody.MovePosition(randomPositionOnScreen);
    }

    // Spawn a single enemy
    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab_[Random.Range(0,_enemyPrefab_.Length)], transform.position, Quaternion.identity);
        enemiesSpawned++;
        enemiesSpawnedTotal++;
        Icons.SetProgress(enemiesSpawnCapIncremental - enemiesSpawned);
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
        enemiesSpawnCapIncremental = Room.enemiesSpawnCap * (1 + (Room.rooms * 0.1f));
        Icons.SetMaxProgress(enemiesSpawnCapIncremental);
        enemiesSpawned = 0;
        SpawnEnemyWaveForLevel();
    }
}
