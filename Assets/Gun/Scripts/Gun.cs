using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletTransform;
    public bool canFire;
    public float delayFire;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        pointTowardsMousePointer();

        if (Input.GetButtonDown("Fire1") && canFire)
        {
            StartCoroutine(fireAlgorithm());
        }
    }

    private IEnumerator fireAlgorithm()
    {
        canFire = false;
        Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(delayFire);
        canFire = true;
    }

    private void pointTowardsMousePointer()
    {
        Vector2 directionToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angleToMouse = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angleToMouse, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100000000000 * Time.deltaTime);
    }
}
