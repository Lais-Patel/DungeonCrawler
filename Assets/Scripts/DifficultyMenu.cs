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
	    if (PlayerPrefs.HasKey("DifficultyRating"))
	    {
		    difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
	    }
        difficultyBar.value = difficultyRating;
		Debug.Log("Difficulty = " + difficultyRating);
		updateDifficultyRating();
    }

    public void updateDifficultyRating()
    {
        difficultyRating = difficultyBar.value;
        PlayerPrefs.SetFloat("DifficultyRating", difficultyRating);
        
        Debug.Log("Difficulty rating = " + difficultyRating);
		Debug.Log("Difficulty value = " + difficultyBar.value);
	
		if (difficultyRating == 1)
		{
			difficultyDescription.text = "Player Health 200%     " +
			                             "Player Damage 200%     " +
			                             "Enemy Spawns 0.5x      ";
			difficultyDescription.color = Color.white;
			
		}
		else if (difficultyRating == 2)
		{
			difficultyDescription.text = "Player Health 100%     " +
			                             "Player Damage 100%     " +
			                             "Enemy Spawns 1x        ";
			difficultyDescription.color = Color.white;
		}
		else if (difficultyRating == 3)
		{
			difficultyDescription.text = "Player Health 75%      " +
			                             "Player Damage 75%      " +
			                             "Enemy Spawns 1.5x      ";
			difficultyDescription.color = Color.white;
		}
		else if (difficultyRating == 4)
		{
			difficultyDescription.text = "Player Health 5%        " +
			                             "Player Damage 50%      " +
			                             "Enemy Spawns 3x        ";
			difficultyDescription.color = Color.red;
		}
    }
}