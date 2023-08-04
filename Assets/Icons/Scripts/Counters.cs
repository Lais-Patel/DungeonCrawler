using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counters : MonoBehaviour
{
    public Text healthTextUI;
    public Text defenceTextUI;
    public Text roomsTextUI;
    public Slider sliderHealthBar;
    
    public void SetMaxHealth(float health)
    {
        sliderHealthBar.maxValue = health;
        sliderHealthBar.value = health;
        healthTextUI.text = health.ToString();
    }

    public void SetHealth(float health)
    {
        sliderHealthBar.value = health;
        healthTextUI.text = health.ToString();
    }

    public void SetDefence(float defence)
    {
        defenceTextUI.text = defence.ToString();
    }

    public void SetRooms(float rooms)
    {
        roomsTextUI.text = rooms.ToString();
    }


}