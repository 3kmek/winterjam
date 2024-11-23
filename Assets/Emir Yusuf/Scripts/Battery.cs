using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battery : MonoBehaviour
{
    [SerializeField] float batteryMax = 100f;
    [SerializeField] float decreaseRatio = 0.5f;
    [SerializeField] Slider slider;

    // Update is called once per frame
    void Update()
    {
        batteryMax -= decreaseRatio* Time.deltaTime;
        slider.value = batteryMax;
        
    }

    public bool isBatteryDead()
    {
        return batteryMax < 0;
    }

    public void IncreaseBattery(float amount)
    {
        batteryMax += amount;
        batteryMax = batteryMax % 100;
    }
}
