using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyMenu : MonoBehaviour
{
    public Slider difficultyBar;
	public TextMeshProUGUI difficultyDescription;
    public static float difficultyRating;
    
    
    // Start is called before the first frame update
    void Start()
    {
        difficultyRating = 2f;
        difficultyBar.value = difficultyRating;
		Debug.Log("Difficulty = " + difficultyRating);
		updateDifficultyRating();
    }

    public void updateDifficultyRating()
    {
        difficultyRating = difficultyBar.value;
        Debug.Log("Difficulty rating = " + difficultyRating);
		Debug.Log("Difficulty value = " + difficultyBar.value);
	
		if (difficultyRating == 1)
		{
			difficultyDescription.text = "Placeholder 1";
		}
		else if (difficultyRating == 2)
		{
			difficultyDescription.text = "Placeholder 2";
		}
		else if (difficultyRating == 3)
		{
			difficultyDescription.text = "Placeholder 3";
		}
		else if (difficultyRating == 4)
		{
			difficultyDescription.text = "Placeholder 4";
		}
    }
}
