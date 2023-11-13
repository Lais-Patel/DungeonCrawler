using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : Entity
{
    public float dashPower;
    public float dashLength;
    public float dashCooldown;
    private bool hasPressedDash;
    private bool canDash = true;
    

    //public List<UpgradeItem> upgradeInventory = new List<UpgradeItem>();
	
    public Counters Icons;

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
        float damageDealt = attackPower * float.Parse("1."+Upgrades.upgradeShop[0,1]);
        return damageDealt;
    }
}
