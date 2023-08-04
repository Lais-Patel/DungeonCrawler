using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float dashPower;
    public float dashLength;
    public float dashCooldown;
    private bool hasPressedDash;
    private bool canDash = true;
    public Counters Icons;
    //private array upgradeinventory;

    //constructor
    void Start()
    {
        dashPower = 20f;
        dashLength = 0.15f;
        dashCooldown = 1f;

        health = 10f;
        defence = 5f;
        Icons.SetMaxHealth(health);
        Icons.SetDefence(defence);
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerControlAlgorithm();
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        if (!hasPressedDash)
        {
            velocity = maxSpeed;
        }

        EntityMovementCalc();
    }

    // Checks for user input
    public void  PlayerControlAlgorithm()
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

    // Validates if user can dash
    private IEnumerator dashAlgorithm()
    {
        health -= 1;
        Icons.SetHealth(health);
        hasPressedDash = true;
        canDash = false;
        velocity = dashPower;
        EntityMovementCalc();
        yield return new WaitForSeconds(dashLength);
        hasPressedDash = false;
        yield return new  WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

