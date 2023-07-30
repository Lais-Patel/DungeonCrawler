using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float velocity;
    public float acceleration = 0.1f;
    public Rigidbody2D rb;

    public float dashPower = 10f;
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;
    private bool hasPressedDash;
    private bool canDash = true;

    private Vector2 directionMovement;
    private Vector2 directionMovementSmooth;
    private Vector2 directionMovementSmoothRef;

    public Animator animationController;

    // Update is called once per frame
    void Update()
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
        
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        if (hasPressedDash)
        {
            return;
        }
        else if (!hasPressedDash)
        {
            velocity = maxSpeed;
        }

        EntityMovementCalc();
    }

    private void EntityMovementCalc()
    {
        directionMovementSmooth = Vector2.SmoothDamp(directionMovementSmooth, directionMovement, ref directionMovementSmoothRef, acceleration);
        rb.MovePosition(rb.position + directionMovementSmooth * Time.fixedDeltaTime * velocity);
    }

    private IEnumerator dashAlgorithm()
    {
        hasPressedDash = true;
        canDash = false;
        velocity = dashPower;
        directionMovementSmooth = Vector2.SmoothDamp(directionMovementSmooth, directionMovement, ref directionMovementSmoothRef, acceleration);
        rb.MovePosition(rb.position + directionMovementSmooth * Time.fixedDeltaTime * velocity);
        yield return new WaitForSeconds(dashLength);
        hasPressedDash = false;
        yield return new  WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
