using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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

    //constructor
    void Start()
    {
        dashPower = 20f;
        dashLength = 0.15f;
        dashCooldown = 1f;

        health = 100f;
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
        hasPressedDash = true;
        canDash = false;
        velocity = dashPower;
        EntityMovementCalc();
        yield return new WaitForSeconds(dashLength);
        hasPressedDash = false;
        yield return new  WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void enemyMeleeAttack(float damageDealt)
    {
        health -= calculateDamageTaken(defence, damageDealt);
        Icons.SetHealth(health);
    }

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

