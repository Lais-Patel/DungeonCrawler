using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class DifficultyMenu : MonoBehaviour
{
    public Slider DifficultyBar;                   // Slider UI reference
	public TextMeshProUGUI DifficultyDescription;  // Text UI element for the description of the difficultly
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

	    DifficultyBar.value = difficultyRating;
		UpdateDifficultyRating();
    }
	
    // Updates the difficulty of the game, as well as description of it
    public void UpdateDifficultyRating()
    {
        difficultyRating = DifficultyBar.value;
        PlayerPrefs.SetFloat("DifficultyRating", difficultyRating);
        
		if (difficultyRating == 1)
		{
			DifficultyDescription.text = "Player Health 200%     " +
			                             "Player Damage 200%     " +
			                             "Enemy Spawns 0.5x      ";
			DifficultyDescription.color = Color.white;
			
		}
		else if (difficultyRating == 2)
		{
			DifficultyDescription.text = "Player Health 100%     " +
			                             "Player Damage 100%     " +
			                             "Enemy Spawns 1x        ";
			DifficultyDescription.color = Color.white;
		}
		else if (difficultyRating == 3)
		{
			DifficultyDescription.text = "Player Health 75%      " +
			                             "Player Damage 75%      " +
			                             "Enemy Spawns 1.5x      ";
			DifficultyDescription.color = Color.white;
		}
		else if (difficultyRating == 4)
		{
			DifficultyDescription.text = "Player Health 5%        " +
			                             "Player Damage 50%      " +
			                             "Enemy Spawns 3x        ";
			DifficultyDescription.color = Color.red;
		}
    }
}
