using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyMenu : MonoBehaviour
{
    public Slider difficultyBar;
    public static float difficultyRating;
    
    
    // Start is called before the first frame update
    void Start()
    {
        difficultyRating = 2f;
        difficultyBar.value = difficultyRating;
    }

    public void updateDifficultyRating()
    {
        difficultyRating = difficultyBar.value;
        Debug.Log("Difficulty = " + difficultyRating);
    }
}
