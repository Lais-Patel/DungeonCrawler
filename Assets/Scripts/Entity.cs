using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Public properties for entity attributes
    public float maxSpeed;
    public float velocity;
    public float acceleration;
    public Rigidbody2D rb;
    public static float health;
    public float defence;
    public static float attackPower;
    public float damageTaken;
    public float damageDealt;
    public Vector2 directionMovement;
    public Vector2 directionMovementSmooth;
    public Vector2 directionMovementSmoothRef;
    public Animator animationController;

    // Awake is called when the script is initialized
    void Awake()
    {
        // Set default values for maxSpeed and acceleration
        maxSpeed = 3f;
        acceleration = 0.1f;
    }
    
    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        // Calculate and update entity movement
        EntityMovementCalc();
    }

    // Calculates and updates the new position of the entity
    public void EntityMovementCalc()
    {
        directionMovementSmooth = Vector2.SmoothDamp(directionMovementSmooth, directionMovement, ref directionMovementSmoothRef, acceleration);
        rb.MovePosition(rb.position + directionMovementSmooth * Time.fixedDeltaTime * velocity);
    }

    // Calculate the damage taken by the entity
    public float calculateDamageTaken(float defence, float damageDealt)
    {   
        damageTaken = (damageDealt - defence * 0.2f);
        // Makes sure that a negative value is sent through
        if (damageTaken <= 0)
        {
            return 0f;
        }
        else
        {
            return damageTaken;
        }
    }
}
