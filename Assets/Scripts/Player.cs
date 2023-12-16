using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : Entity
{
    public float dashPower;                // How much force the player dashes with
    public float dashLength;               // How long the dash lasts
    public float dashCooldown;             // The cooldown between when the player can dash
    public bool hasPressedDash;            // If the player is currently dashing
    private bool canDash = true;           // If the player is allowed to dash
    public Counters Icons;                 // Reference to the Counters Script
	[SerializeField] private Menus Menus;  // Reference to the Menus Script

    // Start is called before the first frame update
    void Start()
    {
        // Set default values for player attributes
        dashPower = 20f;
        dashLength = 0.15f;
        dashCooldown = 1f;
        defence = 5f;

        // Set initial values for health and defence in the UI
        Icons.SetMaxHealth(health);
        Icons.SetDefence(defence);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player control
        PlayerControlAlgorithm();

		if (health <= 0)
		{
			Menus.endGame();
		}
    }

    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        if (!hasPressedDash)
        {
            velocity = maxSpeed;
        }

        // Calculate and update entity movement
        EntityMovementCalc();
    }

    // Handle player control
    public void PlayerControlAlgorithm()
    {
        if (hasPressedDash || Menus.isGamePaused)
        {
            return;
        }

        // Get player input for movement
        directionMovement.x = Input.GetAxisRaw("Horizontal");
        directionMovement.y = Input.GetAxisRaw("Vertical");

        // Set animation parameters based on movement
        animationController.SetFloat("Vertical", directionMovement.y);
        animationController.SetFloat("Horizontal", directionMovement.x);
        animationController.SetFloat("Velocity", directionMovement.sqrMagnitude);

        directionMovement = directionMovement.normalized;

        // Check for dashing input
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(dashAlgorithm());
        }
    }

    // Dash behavior
    private IEnumerator dashAlgorithm()
    {
        hasPressedDash = true;
        canDash = false;
        velocity = dashPower;
        EntityMovementCalc();
        yield return new WaitForSeconds(dashLength);
        hasPressedDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    // Handle enemy melee attack
    public void enemyMeleeAttack( float damageDealt)
    {
        health -= calculateDamageTaken(defence, damageDealt);
        Icons.SetHealth(health);
    }
    
    //Calculate the damage dealt by the entity
    public static float calculateDamageDealt()
    {
        float damageDealt = attackPower;
        return damageDealt;
    }
}
