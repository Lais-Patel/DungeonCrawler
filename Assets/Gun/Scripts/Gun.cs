using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;     // Prefab for the bullet to be fired
    public Transform bulletTransform;   // Transform where bullets will spawn
    public bool canFire;                // Boolean to control firing
    public float delayFire;             // Delay between shots

    // Start is called before the first frame update
    void Start()
    {
        canFire = true; // Enable firing at the start
    }

    // Update is called once per frame
    void Update()
    {
        pointTowardsMousePointer(); // Point the gun towards the mouse pointer

        // Check for user input to fire bullets
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            StartCoroutine(fireAlgorithm()); // Start firing sequence
        }
    }

    // Coroutine to handle the firing sequence
    private IEnumerator fireAlgorithm()
    {
        canFire = false; // Disable firing during the sequence
        Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity); // Spawn a bullet
        yield return new WaitForSeconds(delayFire); // Wait for the specified delay
        canFire = true; // Enable firing again
    }

    // Point the gun towards the mouse pointer
    private void pointTowardsMousePointer()
    {
        Vector2 directionToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angleToMouse = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angleToMouse, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100000000000 * Time.deltaTime);
    }
}
