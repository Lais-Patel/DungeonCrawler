using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private static float timeLeftOnClock;
    private static bool timerOn;

    public TextMeshProUGUI TimerText;
    public EnemySpawner enemySpawner;
    
    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            updateTimerText();
            if (timeLeftOnClock > 0)
            {
                timeLeftOnClock -= Time.deltaTime;
            }
            else
            {
                timeLeftOnClock = 0;
                TimerText.text = "";
                timerOn = false;
                enemySpawner.StartNextLevel();
            }
        }
    }
    
    private void updateTimerText()
    {
        TimerText.text = timeLeftOnClock.ToString("F0");
    }

    public static void StartCountdown(float timeToSet)
    {
        timerOn = true;
        timeLeftOnClock = timeToSet;
    }
}
