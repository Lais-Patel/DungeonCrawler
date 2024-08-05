using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Countdown : MonoBehaviour
{
    private static float timeLeftOnClock;    // How long is left on the timer
    private static bool timerOn;             // If the timer is on or not
    public TextMeshProUGUI TimerText;        // Text UI for displaying the timer
    public EnemySpawner EnemySpawner;        // Reference to the enemy spawner script
    
    // Update is called once per frame
    void Update()
    {
        // Checks if the timer is active, then updates the timer text
        if (timerOn)
        {
            UpdateTimerText();
            // Checks if there is any time left on the timer
            // if there is it will decrement it
            // else it will ensure the timer is on 0 turn it off and start a new level
            if (timeLeftOnClock > 0)
            {
                timeLeftOnClock -= Time.deltaTime;
            }
            else
            {
                timeLeftOnClock = 0;
                TimerText.text = "";
                timerOn = false;
                EnemySpawner.StartNextLevel();
            }
        }
    }
    
    // Updates the text on the timer and ensures it has no decimal places
    private void UpdateTimerText()
    {
        TimerText.text = timeLeftOnClock.ToString("F0");
    }

    // Begins a new timer based on the inputted value
    public static void StartCountdown(float timeToSet)
    {
        timerOn = true;
        timeLeftOnClock = timeToSet;
    }
}
