using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rangeTime;      // Time until bullet is destroyed
    public float size;           // Bullet size
    public float bulletForce;    // Bullet speed
    private Rigidbody2D rb;     // Rigidbody component
    
    public bool hitEnemy = false;

    // Awake is called when the script is initialized
    void Awake()
    {
        // Set default bullet properties
        rangeTime = 3f;
        size = .2f;
        bulletForce = 8f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Calculate direction to the mouse cursor
        Vector3 directionToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 angleToMouse = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D

        // Set bullet velocity and rotation towards the cursor
        rb.velocity = new Vector2(directionToMouse.x, directionToMouse.y).normalized * bulletForce;
        float rotation = Mathf.Atan2(angleToMouse.y, angleToMouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90); // Adjust rotation
    }

    // Update is called once per frame
    void Update()
    {
        // Update the bullet's size (scale)
        transform.localScale = new Vector3(size, size, size);
    }

    // Called when another 2D collider enters this trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the bullet if it collides with Walls or Enemies
        if (other.CompareTag("Upper Walls") || other.CompareTag("Enemies"))
        {
            Destroy(gameObject);
        }
    }
}
