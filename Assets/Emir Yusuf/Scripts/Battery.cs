using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battery : MonoBehaviour
{
    [SerializeField] float batteryMax = 100f;
    [SerializeField] float decreaseRatio = 0.5f;
    [SerializeField] float chargeAmount = 2.0f;
    [SerializeField] Slider slider;
    [SerializeField] float decreaseAmount = 2.0f;
    [SerializeField] GameObject Incvfx;
    [SerializeField] GameObject Decvfx;
    [SerializeField] float vfxDuration = 2f;
    float targetTimeINC;
    float targetTimeDEC;
    
    [SerializeField] public LevelManager levelManager;

    // Update is called once per frame
    void Update()
    {
        batteryMax -= decreaseRatio* Time.deltaTime;
        slider.value = batteryMax;
        if (targetTimeINC < Time.time)
        {
            Incvfx.SetActive(false);
        }
        if (targetTimeDEC < Time.time)
        {
            Decvfx.SetActive(false);
        }

        if (batteryMax <= 0f)
        {
            
        }
    }

    public bool isBatteryDead()
    {
        return batteryMax < 0;
    }

    public void ChangeBattery(float amount)
    {
        batteryMax += amount;
        batteryMax = batteryMax>100 ? 100 : batteryMax;
    }

    public void IncreaseBattery()
    {
        batteryMax += chargeAmount;
        batteryMax = batteryMax > 100 ? 100 : batteryMax;
        Incvfx.SetActive(true);
        targetTimeINC = Time.time + vfxDuration;
    }
    
    public void DecreaseBattery()
    {
        batteryMax -= decreaseAmount;
        batteryMax = batteryMax > 100 ? 100 : batteryMax;
        Decvfx.SetActive(true);
        targetTimeDEC = Time.time + vfxDuration;
    }
    
    
    
}
