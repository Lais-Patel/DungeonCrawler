using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyMenu : MonoBehaviour
{
    public Slider difficultyBar;                   // Slider UI reference
	public TextMeshProUGUI difficultyDescription;  // Text UI element for the description of the difficultly
    public static float difficultyRating;          // The difficulty the game is set to
    
    
    // Start is called before the first frame update
    void Start()
    {
	    if (PlayerPrefs.HasKey("DifficultyRating"))
	    {
		    difficultyRating = PlayerPrefs.GetFloat("DifficultyRating");
	    }
	    else
	    {
		    difficultyRating = 2f;
	    }

	    difficultyBar.value = difficultyRating;
		updateDifficultyRating();
    }
	
    // Updates the difficulty of the game, as well as description of it
    public void updateDifficultyRating()
    {
        difficultyRating = difficultyBar.value;
        PlayerPrefs.SetFloat("DifficultyRating", difficultyRating);
        
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
