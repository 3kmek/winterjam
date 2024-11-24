using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] Product[] products;
    [SerializeField] Image[] images;
    [SerializeField] Battery battery;
    [HideInInspector] public List<Product> currentTasks;
    int proIndex;

    // Start is called before the first frame update
    void Start()
    {
        images[0].sprite = products[0].sprite;
        images[1].sprite = products[1].sprite;
        images[2].sprite = products[2].sprite;
        currentTasks[0] = products[0];
        currentTasks[1] = products[1];
        currentTasks[2] = products[2];
        proIndex = 3;
    }


    public void Sold(int index)
    {
        battery.IncreaseBattery();
        if (proIndex >= products.Length)
        {
            LevelComplete();
        }
        else
        {
            images[index].sprite = products[proIndex].sprite;
            currentTasks[index] = products[proIndex];
            proIndex++;
        }

    }

    void LevelComplete()
    {
        Debug.Log("level bitti digerine gec");
    }
}
