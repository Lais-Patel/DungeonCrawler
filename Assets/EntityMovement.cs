using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float velocity;
    public float acceleration = 0.6f;
    public Rigidbody2D rb;
    Vector2 directionMovement;
    public float framesSincePressed;

    // Update is called once per frame
    void Update()
    {
        directionMovement.x = Input.GetAxisRaw("Horizontal");
        directionMovement.y = Input.GetAxisRaw("Vertical");
        directionMovement = directionMovement.normalized;
        
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        if (directionMovement.x != 0 || directionMovement.y != 0)
        {
            CountFramesSincePressed();
        }
        else if (directionMovement.x == 0 && directionMovement.y == 0)
        {
            framesSincePressed = 0;
        }

        velocity = framesSincePressed;

        if (velocity > maxSpeed)
        {
            velocity = maxSpeed;
        }
        else if (velocity < 0)
        {
            velocity = 0;
        }

        rb.MovePosition(rb.position + directionMovement * Time.fixedDeltaTime * velocity);
    }

    void CountFramesSincePressed()
    {
        framesSincePressed += acceleration;
    }
    
}
