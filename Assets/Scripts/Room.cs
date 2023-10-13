using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float rooms = 1;     // Number of rooms cleared
    public Counters Icons;      // Reference to the Counters script for UI updates
    public static float difficultyRating;
    public static float enemiesSpawnCap;
    public static float difficultySpawnCap;

    private float enemiesSpawnCapBase = 5;
    private float difficultySpawnCapBase = 10;
    
    private float playerHealthBase = 100;
    private float playerAttackBase = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("DifficultyRating"))
        {
            difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
        }
        
        if (difficultyRating == 1)
        {
            enemiesSpawnCap = enemiesSpawnCapBase * 0.5f;
            difficultySpawnCap = difficultySpawnCapBase * 0.5f;
            
            Player.health = playerHealthBase * 2f;
            Icons.SetHealth(Player.health);
            Player.attackPower = playerAttackBase * 2f;
        }
        else if (difficultyRating == 2)
        {
            enemiesSpawnCap = enemiesSpawnCapBase;
            difficultySpawnCap = difficultySpawnCapBase;
        }
        else if (difficultyRating == 3)
        {
            enemiesSpawnCap = enemiesSpawnCapBase * 1.5f;
            difficultySpawnCap = difficultySpawnCapBase * 1.5f;
            
            Player.health = playerHealthBase * 0.75f;
            Icons.SetHealth(Player.health);
            Player.attackPower = playerAttackBase * 0.75f;
        }
        else if (difficultyRating == 4)
        {
            enemiesSpawnCap = enemiesSpawnCapBase * 3f;
            difficultySpawnCap = difficultySpawnCapBase * 3f;
            
            Player.health = playerHealthBase * 0.05f;
            Icons.SetHealth(Player.health);
            Player.attackPower = playerAttackBase * 0.5f;
        }
        
        
        // Initialize the UI with the initial room count
        Icons.SetRooms(rooms);
    }

    // Increment the room count and update the UI
    public void IncrementRoomCount()
    {
        rooms++;
        Icons.SetRooms(rooms);
        
    }
}
