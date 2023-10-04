using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rangeTime;
    public float size;
    public float bulletForce;
    private Rigidbody2D rb;

    //constructor
    void Awake()
    {
        rangeTime = 3f;
        size = .2f;
        bulletForce = 8f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 directionToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 angleToMouse = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(directionToMouse.x, directionToMouse.y).normalized * bulletForce;
        float rotation = Mathf.Atan2(angleToMouse.y, angleToMouse.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size, size, size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemies"))
        {
            Destroy(gameObject);
        } 
    }
}
