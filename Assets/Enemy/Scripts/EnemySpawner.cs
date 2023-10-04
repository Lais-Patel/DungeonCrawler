using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemySpawnDelay;

    [SerializeField]
    private bool enemySpawnOn = true;

    private Vector3 randomPositionOnScreen;
    public Rigidbody2D rb;
    private float timeUntilEnemySpawn;
    private float EnemiesPerLevel = 20;
    private float EnemiesSpawnedInLevel = 0;
    public Room Room;

    // Start is called before the first frame update
    void Awake()
    {
        StartNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilEnemySpawn -= Time.deltaTime;
        if (enemySpawnOn)
        {
            SpawnEnemyWaveForLevel();
        }
    }

    private void TimeUntilNextSpawn()
    {
        timeUntilEnemySpawn = Random.Range(enemySpawnDelay, enemySpawnDelay + 2);
    }

    void MoveToRandomPosition()
    {
        float x = Random.Range(-5f, 6.9f); 
        float y = Random.Range(-3.6f, 2.85f);

        randomPositionOnScreen = new Vector3(x, y, transform.position.z);
        rb.MovePosition(randomPositionOnScreen);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemiesSpawnedInLevel++;
        TimeUntilNextSpawn();
        MoveToRandomPosition();
        if (EnemiesSpawnedInLevel == 20)
        {
            StartNextLevel();
        }
    }
    public void SpawnEnemyWaveForLevel()
    {   
        if (timeUntilEnemySpawn <= 0) 
        {
        if (EnemiesSpawnedInLevel != EnemiesPerLevel)
        {
            SpawnEnemy();
        }
        }
    }

    public void StartNextLevel()
    {
        Room.IncrementRoomCount();
        EnemiesPerLevel = 20;
        EnemiesSpawnedInLevel = 0;
        SpawnEnemyWaveForLevel();
    }
}