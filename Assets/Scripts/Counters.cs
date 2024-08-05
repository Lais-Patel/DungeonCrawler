using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class Counters : MonoBehaviour
{
    public TextMeshProUGUI HealthTextUI;           // Text UI for displaying health
    public TextMeshProUGUI DefenceTextUI;          // Text UI for displaying defence
    public TextMeshProUGUI RoomsTextUI;            // Text UI for displaying rooms
    public TextMeshProUGUI EnemyKilledTextUI;      // Text UI for displaying enemies killed
    public Slider SliderHealthBar;                 // Health bar slider
    public Slider SliderProgressBar;               // Progress bar slider
    public float enemiesFelledCount;               // Counter for enemies defeated
    
    // Set the maximum health for the health bar
    public void SetMaxHealth(float health)
    {
        SliderHealthBar.maxValue = health;
        SliderHealthBar.value = health;
        HealthTextUI.text = health.ToString();
    }

    // Set the current health value on the health bar
    public void SetHealth(float health)
    {
        SliderHealthBar.value = health;
        HealthTextUI.text = Mathf.RoundToInt(health).ToString();
    }
    
    public void SetMaxProgress(float progress)
    {
        SliderProgressBar.maxValue = progress;
        SliderProgressBar.value = progress;
    }

    // Set the current health value on the health bar
    public void SetProgress(float progress)
    {
        SliderProgressBar.value = progress;
    }
	
    // Increases the maximum value of the health bar
	public void UpgradeHealth(float percentageIncrease)
	{
		SliderHealthBar.maxValue *= percentageIncrease;
	}

    // Set the defence value
    public void SetDefence(float defence)
    {
        DefenceTextUI.text = Mathf.RoundToInt(defence).ToString();
    }

    // Set the number of rooms
    public void SetRooms(float rooms)
    {
        RoomsTextUI.text = rooms.ToString();
    }

    // Set the number of enemies killed
    public void SetEnemiesKilled(float enemiesFelledCount)
    {
        EnemyKilledTextUI.text = enemiesFelledCount.ToString();
    }

    // Increment the enemy killed count and update the display
    public void IncrementEnemeyFelledCount()
    {
        enemiesFelledCount++;
        SetEnemiesKilled(enemiesFelledCount);
    }
}
