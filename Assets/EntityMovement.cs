using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 directionMovement;

    // Update is called once per frame
    void Update()
    {
        directionMovement.x = Input.GetAxisRaw("Horizontal");
        directionMovement.y = Input.GetAxisRaw("Vertical");
    }

    // Update is called at fixed increments
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + directionMovement * maxSpeed * Time.fixedDeltaTime);
    }
}
