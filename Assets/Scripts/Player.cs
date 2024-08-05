using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Entity
{
    public float dashPower;                // How much force the player dashes with
    public float dashLength;               // How long the dash lasts
    public float dashCooldown;             // The cooldown between when the player can dash
    public static bool hasPressedDash;            // If the player is currently dashing
    private bool canDash = true;           // If the player is allowed to dash
    public Counters Counters;                 // Reference to the Counters Script
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
        Counters.SetMaxHealth(health);
        Counters.SetDefence(defence);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player control
        PlayerControlAlgorithm();

		if (health <= 0)
		{
			Menus.EndGame();
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
        AnimationController.SetFloat("Vertical", directionMovement.y);
        AnimationController.SetFloat("Horizontal", directionMovement.x);
        AnimationController.SetFloat("Velocity", directionMovement.sqrMagnitude);

        directionMovement = directionMovement.normalized;

        // Check for dashing input
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(DashAlgorithm());
        }
    }

    // Dash behavior
    private IEnumerator DashAlgorithm()
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
    public void EnemyMeleeAttack(float damageDealt)
    {
        health -= CalculateDamageTaken(defence, damageDealt);
        Counters.SetHealth(health);
    }
    
    //Calculate the damage dealt by the entity
    public static float CalculateDamageDealt()
    {
        float damageDealt = attackPower;
        return damageDealt;
    }
}
