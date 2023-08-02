using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemySpawnDelay;

    private Vector3 randomPositionOnScreen;
    public Rigidbody2D rb;
    private float timeUntilEnemySpawn;

    // Start is called before the first frame update
    void Awake()
    {
        TimeUntilNextSpawn();
    }

    // Update is called once per frame
    void Update()
    {
         timeUntilEnemySpawn -= Time.deltaTime;

        if (timeUntilEnemySpawn <= 0) 
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            TimeUntilNextSpawn();
            MoveToRandomPosition();
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
}

