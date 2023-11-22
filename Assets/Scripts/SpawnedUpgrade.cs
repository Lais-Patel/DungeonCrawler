using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedUpgrade : MonoBehaviour
{
    public int numberOfTheUpgrade;
    private Renderer Renderer;
    private Color colour;

    void Start()
    {
        numberOfTheUpgrade = Random.Range(0, 4);
        
        Debug.Log(numberOfTheUpgrade);
        
        if (numberOfTheUpgrade == 0)
        {
            ColorUtility.TryParseHtmlString("#983944", out colour);
        }
        else if (numberOfTheUpgrade == 1)
        {
            ColorUtility.TryParseHtmlString("#D95763", out colour);
        }
        else if (numberOfTheUpgrade == 2)
        {
            ColorUtility.TryParseHtmlString("#8895AF", out colour);
        }
        else if (numberOfTheUpgrade == 3)
        {
            ColorUtility.TryParseHtmlString("#5DA863", out colour);
        }
        else if (numberOfTheUpgrade == 4)
        {
            ColorUtility.TryParseHtmlString("#F77622", out colour);
        }
        
        Debug.Log(colour);
        
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = colour;
    }
}
