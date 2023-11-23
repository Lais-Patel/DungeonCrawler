using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    
    [SerializeField]
    private Counters Counters;
    
    [SerializeField]
    private Room Room;
    
    public TextMeshProUGUI scoreBreakdown;

	private float gameScore;
    
	public void calculateGameScore()
	{
		gameScore = Counters.enemiesFelledCount * Room.rooms * PlayerPrefs.GetFloat("DifficultyRating");
	}

	public void updateScoreScreen()
	{
		calculateGameScore();
		scoreBreakdown.text = "SCORE          " + "\n" +
			                  "Enemy Kills   : " + Counters.enemiesFelledCount + "\n" +
			                  "Rooms Cleared : " + Room.rooms + "\n" +
							  "Score Acheived: " + gameScore;	
	}
}
