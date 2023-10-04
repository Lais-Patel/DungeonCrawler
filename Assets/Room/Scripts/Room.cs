using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float rooms = 0;
    public Counters Icons;

    // Start is called before the first frame update
    void Start()
    {
        Icons.SetRooms(rooms);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementRoomCount()
    {
        rooms++;
        Icons.SetRooms(rooms);
    }
}
