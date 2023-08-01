using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject player; 
    public float distanceFromPlayer;

    //constructor
    void Awake()
    {
        maxSpeed = 2f;
        acceleration = 0.0333f;
    }


    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionMovement = player.transform.position - transform.position;

        animationController.SetFloat("Vertical", directionMovement.y);
        animationController.SetFloat("Horizontal", directionMovement.x);
        animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        velocity = maxSpeed;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, maxSpeed * Time.fixedDeltaTime);
        EntityMovementCalc();      
    }
}
