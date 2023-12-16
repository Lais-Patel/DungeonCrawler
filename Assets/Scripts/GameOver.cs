using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] private Counters Counters;  // Reference to the Counters Script
    [SerializeField] private Room Room;          // Reference to the Room Script
    public TextMeshProUGUI scoreBreakdown;       // Text UI for the breakdown of the score
	private float gameScore;                     // Stores the value for the score gained
    
	// Calculates the game score
	public void calculateGameScore()
	{
		gameScore = Counters.enemiesFelledCount * Room.rooms * PlayerPrefs.GetFloat("DifficultyRating");
	}
 
	// Updates the score breakdown
	public void updateScoreScreen()
	{
		calculateGameScore();
		scoreBreakdown.text = "SCORE          " + "\n" +
			                  "Enemy Kills : " + Counters.enemiesFelledCount + "\n" +
			                  "Rooms Cleared Multiplier : " + Room.rooms + "x \n" +
							  "Difficulty Multiplier : " + PlayerPrefs.GetFloat("DifficultyRating") + "x \n" +
							  "Score Acheived  :::  " + gameScore;	
	}
}
