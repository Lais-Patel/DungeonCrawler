using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemySpawnDelay;

    private float timeUntilEnemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilEnemySpawn -= timeUntilEnemySpawn.deltaTime;

        if (timeUntilEnemySpawn <= 0) 
        {
            Instantiate(enemyPrefab, transform.position);
            TimeUntilNextSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TimeUntilNextSpawn()
    {
        timeUntilEnemySpawn = Random.Range(enemySpawnDelay - 2, enemySpawnDelay + 2);
    }
}

