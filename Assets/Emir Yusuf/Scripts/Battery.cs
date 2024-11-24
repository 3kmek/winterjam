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
    [SerializeField] GameObject vfx;
    [SerializeField] float vfxDuration = 2f;
    float targetTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IncreaseBattery();
        }
        batteryMax -= decreaseRatio* Time.deltaTime;
        slider.value = batteryMax;
        if (targetTime < Time.time)
        {
            vfx.SetActive(false);
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
        vfx.SetActive(true);
        targetTime = Time.time + vfxDuration;
    }
    
    public void DecreaseBattery()
    {
        batteryMax -= decreaseAmount;
        batteryMax = batteryMax > 100 ? 100 : batteryMax;
    }
}
