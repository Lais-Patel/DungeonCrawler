using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxSpeed;
    public float velocity;
    public float acceleration;
    public Rigidbody2D rb;

    public float health;
    public float defence;
    public float attackPower;
    public float damageTaken;
    public float damageDealt;

    public Vector2 directionMovement;
    public Vector2 directionMovementSmooth;
    public Vector2 directionMovementSmoothRef;

    public Animator animationController;

    //constructor
    void Awake()
    {
        maxSpeed = 6f;
        acceleration = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        EntityMovementCalc();
    }

    // Calculates and updates the new position of the entity
    public void EntityMovementCalc()
    {
        directionMovementSmooth = Vector2.SmoothDamp(directionMovementSmooth, directionMovement, ref directionMovementSmoothRef, acceleration);
        rb.MovePosition(rb.position + directionMovementSmooth * Time.fixedDeltaTime * velocity);
    }
}
