using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Room : MonoBehaviour
{
    public float rooms = 0;                      // Number of rooms cleared
    public Counters Icons;                       // Reference to the Counters script for UI updates
    public static float difficultyRating;        // Stores the difficulty of the game
    public static float enemiesSpawnCap;         // Value of how many enemies can spawn
    private float enemiesSpawnCapBase = 5f;      // Base value of how many enemies can spawn
    private float playerHealthBase = 100f;       // Base value of how much health the player has
    private float playerAttackBase = 10f;        // Base value of how much attack the player has

    // Start is called before the first frame update
    void Start()
    {   // Finds the difficulty of the game
        difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
        
        // Checks what the difficulty of the game is set to and applies the changes
        if (difficultyRating == 1) // Easy
        {
            enemiesSpawnCap = enemiesSpawnCapBase * 0.5f;
            Player.health = playerHealthBase * 2f;
            Icons.SetMaxHealth(Player.health);
            Player.attackPower = playerAttackBase * 2f;
        }
        else if (difficultyRating == 2) // Normal
        {
            enemiesSpawnCap = enemiesSpawnCapBase;
            Player.health = playerHealthBase * 1f;
            Icons.SetMaxHealth(Player.health);
            Player.attackPower = playerAttackBase * 1f;
        }
        else if (difficultyRating == 3) // Hard
        {
            enemiesSpawnCap = enemiesSpawnCapBase * 1.5f;
            Player.health = playerHealthBase * 0.75f;
            Icons.SetMaxHealth(Player.health);
            Player.attackPower = playerAttackBase * 0.75f;
        }
        else if (difficultyRating == 4) // Expert
        {
            enemiesSpawnCap = enemiesSpawnCapBase * 3f;
            Player.health = playerHealthBase * 0.05f;
            Icons.SetMaxHealth(Player.health);
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
