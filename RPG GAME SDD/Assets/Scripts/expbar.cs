using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expbar : MonoBehaviour
{

    public Slider slider;


    public void SetMaxExp(int exp)//Sets max slider value to max exp value
    {
        slider.maxValue = exp;
        slider.value = exp;
    }

    public void SetExp(int exp){//Sets Slidervalue to exp value
        slider.value = exp;
    }
}
