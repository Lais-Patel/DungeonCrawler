using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Basic object to store basic data of each type of Upgrade
class UpgradeItem
{
    public string Name { get; set; }
    public float Value1 { get; set; }
    public float Value2 { get; set; }
    public float Value3 { get; set; }
}

public class Player : Entity
{
    public float dashPower;
    public float dashLength;
    public float dashCooldown;
    private bool hasPressedDash;
    private bool canDash = true;
    

    List<UpgradeItem> upgradeInventory = new List<UpgradeItem>();

    public Counters Icons;

    // Start is called before the first frame update
    void Start()
    {
        // Set default values for player attributes
        dashPower = 20f;
        dashLength = 0.15f;
        dashCooldown = 1f;

        health = 100f;
        defence = 5f;
        attackPower = 1f;

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
    public void enemyMeleeAttack(float damageDealt)
    {
        health -= calculateDamageTaken(defence, damageDealt);
        Icons.SetHealth(health);
    }

    // Add upgrades to the player's inventory
    public void addUpgradeToInventory(int numberUpgradeToAdd)
    {
        string[] lines = File.ReadAllLines("upgradeInventoryIndex.txt");

        for (int i = numberUpgradeToAdd; i < numberUpgradeToAdd + 4; i++)
        {
            UpgradeItem item = new UpgradeItem
            {
                Name = lines[i],
                Value1 = float.Parse(lines[i + 1]),
                Value2 = float.Parse(lines[i + 2]),
                Value3 = float.Parse(lines[i + 3])
            };
            upgradeInventory.Add(item);
        }
    }
}
