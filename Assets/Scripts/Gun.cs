using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    public GameObject _bulletPrefab_;     // Prefab for the bullet to be fired
    public Transform BulletTransform;   // Transform where bullets will spawn
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
        PointTowardsMousePointer(); // Point the gun towards the mouse pointer

        // Check for user input to fire bullets
        if ((Input.GetButtonDown("Fire1") || (Input.GetMouseButton(0))) && canFire && !Menus.isGamePaused)
        {
            StartCoroutine(FireAlgorithm()); // Start firing sequence
        }
    }

    // Coroutine to handle the firing sequence
    private IEnumerator FireAlgorithm()
    {
        canFire = false; // Disable firing during the sequence
        Instantiate(_bulletPrefab_, BulletTransform.position, Quaternion.identity); // Spawn a bullet
        yield return new WaitForSeconds(delayFire); // Wait for the specified delay
        canFire = true; // Enable firing again
    }

    // Point the gun towards the mouse pointer
    private void PointTowardsMousePointer()
    {
        Vector2 directionToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angleToMouse = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angleToMouse, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100000000000 * Time.deltaTime);
    }
}
