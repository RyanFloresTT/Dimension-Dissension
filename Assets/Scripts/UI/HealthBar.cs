using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    public void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SetHelth(float health)
    {
        _slider.value = health;
    }
}
