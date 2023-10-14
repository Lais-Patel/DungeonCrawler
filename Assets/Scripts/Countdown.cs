using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class Countdown : MonoBehaviour
{
    private static float timeLeftOnClock;
    private static bool timerOn;

    public static TextMeshProUGUI TimerText;
    public EnemySpawner enemySpawner;
    
    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeftOnClock > 0)
            {
                timeLeftOnClock -= Time.deltaTime;
            }
            else
            {
                timeLeftOnClock = 0;
                timerOn = false;
                enemySpawner.StartNextLevel();
            }
        }
    }
    
    private void updateTimerText()
    {
        TimerText.text = timeLeftOnClock.ToString();
    }

    public static void StartCountdown(float timeToSet)
    {
        timerOn = true;
        timeLeftOnClock = timeToSet;
    }
}
