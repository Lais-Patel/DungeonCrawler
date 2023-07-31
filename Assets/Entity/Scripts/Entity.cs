using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxSpeed;
    public float velocity;
    public float acceleration;
    public Rigidbody2D rb;

    /*public float dashPower;
    public float dashLength;
    public float dashCooldown;
    private bool hasPressedDash;
    private bool canDash = true;*/

    public Vector2 directionMovement;
    public Vector2 directionMovementSmooth;
    public Vector2 directionMovementSmoothRef;

    public Animator animationController;

    //constructor
    public Entity()
    {
        maxSpeed = 6f;
        acceleration = 0.1f;

        /*dashPower = 20f;
        dashLength = 0.15f;
        dashCooldown = 1f;*/
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerControlAlgorithm();
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        /*if (hasPressedDash)
        {
            //return;
        }
        else if (!hasPressedDash)
        {
            velocity = maxSpeed;
        }*/

        EntityMovementCalc();
    }

    // Checks for user input
    /*public void  PlayerControlAlgorithm()
    {
        if (hasPressedDash)
        {
            return;
        }

        directionMovement.x = Input.GetAxisRaw("Horizontal");
        directionMovement.y = Input.GetAxisRaw("Vertical");

        animationController.SetFloat("Vertical", directionMovement.y);
        animationController.SetFloat("Horizontal", directionMovement.x);
        animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);

        directionMovement = directionMovement.normalized;

        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(dashAlgorithm());
        }
    }*/

    // Calculates and updates the new position of the entity
    public void EntityMovementCalc()
    {
        directionMovementSmooth = Vector2.SmoothDamp(directionMovementSmooth, directionMovement, ref directionMovementSmoothRef, acceleration);
        rb.MovePosition(rb.position + directionMovementSmooth * Time.fixedDeltaTime * velocity);
    }

    // Validates if user can dash
    /*private IEnumerator dashAlgorithm()
    {
        hasPressedDash = true;
        canDash = false;
        velocity = dashPower;
        EntityMovementCalc();
        yield return new WaitForSeconds(dashLength);
        hasPressedDash = false;
        yield return new  WaitForSeconds(dashCooldown);
        canDash = true;
    }*/
}
