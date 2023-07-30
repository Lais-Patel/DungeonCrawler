using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float acceleration = 0.6f;
    public Rigidbody2D rb;

    private Vector2 directionMovement;
    private Vector2 directionMovementSmooth;
    private Vector2 directionMovementSmoothRef;

    public Animator animationController;

    // Update is called once per frame
    void Update()
    {
        directionMovement.x = Input.GetAxisRaw("Horizontal");
        directionMovement.y = Input.GetAxisRaw("Vertical");

        animationController.SetFloat("Vertical", directionMovement.y);
        animationController.SetFloat("Horizontal", directionMovement.x);
        animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);

        directionMovement = directionMovement.normalized;
        
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        directionMovementSmooth = Vector2.SmoothDamp(directionMovementSmooth, directionMovement, ref directionMovementSmoothRef, acceleration);

        rb.MovePosition(rb.position + directionMovementSmooth * Time.fixedDeltaTime * maxSpeed);
    }
}
