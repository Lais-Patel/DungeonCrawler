using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float rooms = 0;     // Number of rooms cleared
    public Counters Icons;      // Reference to the Counters script for UI updates

    // Start is called before the first frame update
    void Start()
    {
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
