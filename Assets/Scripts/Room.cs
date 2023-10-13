using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float rooms = 0;     // Number of rooms cleared
    public Counters Icons;      // Reference to the Counters script for UI updates
    public static float difficultyRating;
    public static float enemiesSpawnCap;
    public static float difficultySpawnCap;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("DifficultyRating"))
        {
            difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
        }
        
        if (difficultyRating == 1)
        {
            enemiesSpawnCap = 2.5f;
            difficultySpawnCap = 5f;
            Player.health = (float)(Player.health * 2);
        }
        else if (difficultyRating == 2)
        {
            enemiesSpawnCap = 5f;
            difficultySpawnCap = 10f;
        }
        else if (difficultyRating == 3)
        {
            enemiesSpawnCap = 7.5f;
            difficultySpawnCap = 15f;
            Player.health = (float)(Player.health * 0.75);
        }
        else if (difficultyRating == 4)
        {
            enemiesSpawnCap = 15f;
            difficultySpawnCap = 30f;
            Player.health = (float)(Player.health * 0.05);
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
