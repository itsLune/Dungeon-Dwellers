using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;


    public void SetMaxHealth(int health)//Sets max slider value to max Health  value
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health){//Sets slider value to health value
        slider.value = health;
    }
}
