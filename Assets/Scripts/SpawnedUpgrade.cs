using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedUpgrade : MonoBehaviour
{
    public int numberOfTheUpgrade;

    void Start()
    {
        numberOfTheUpgrade = Random.Range(1, 3);
    }

    public void Die()
    {
        Destroy(gameObject.name("Upgrade"));
    }
}
