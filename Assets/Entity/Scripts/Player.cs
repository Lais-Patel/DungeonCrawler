using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    // Update is called once per frame
    void Update()
    {
        Entity.PlayerControlAlgorithm();
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        if (hasPressedDash)
        {
            //return;
        }
        else if (!hasPressedDash)
        {
            velocity = maxSpeed;
        }

        Entity.EntityMovementCalc();
    }
}
