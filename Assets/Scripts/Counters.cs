using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counters : MonoBehaviour
{
    public TextMeshProUGUI healthTextUI;           // Text UI for displaying health
    public TextMeshProUGUI defenceTextUI;          // Text UI for displaying defence
    public TextMeshProUGUI roomsTextUI;            // Text UI for displaying rooms
    public TextMeshProUGUI enemyKilledTextUI;      // Text UI for displaying enemies killed
    public Slider sliderHealthBar;                 // Health bar slider
    public Slider sliderProgressBar;               // Progress bar slider
    public float enemiesFelledCount;               // Counter for enemies defeated
    
    // Set the maximum health for the health bar
    public void SetMaxHealth(float health)
    {
        sliderHealthBar.maxValue = health;
        sliderHealthBar.value = health;
        healthTextUI.text = health.ToString();
    }

    // Set the current health value on the health bar
    public void SetHealth(float health)
    {
        sliderHealthBar.value = health;
        healthTextUI.text = Mathf.RoundToInt(health).ToString();
    }
    
    public void SetMaxProgress(float progress)
    {
        sliderProgressBar.maxValue = progress;
        sliderProgressBar.value = progress;
    }

    // Set the current health value on the health bar
    public void SetProgress(float progress)
    {
        sliderProgressBar.value = progress;
    }
	
    // Increases the maximum value of the health bar
	public void UpgradeHealth(float percentageIncrease)
	{
		sliderHealthBar.maxValue *= percentageIncrease;
	}

    // Set the defence value
    public void SetDefence(float defence)
    {
        defenceTextUI.text = Mathf.RoundToInt(defence).ToString();
    }

    // Set the number of rooms
    public void SetRooms(float rooms)
    {
        roomsTextUI.text = rooms.ToString();
    }

    // Set the number of enemies killed
    public void SetEnemiesKilled(float enemiesFelledCount)
    {
        enemyKilledTextUI.text = enemiesFelledCount.ToString();
    }

    // Increment the enemy killed count and update the display
    public void IncrementEnemeyFelledCount()
    {
        enemiesFelledCount++;
        SetEnemiesKilled(enemiesFelledCount);
    }
}
