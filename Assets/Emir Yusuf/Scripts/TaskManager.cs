using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] Product[] TasksObjects;
    [SerializeField] Image[] images;
    [SerializeField] Battery battery;
    [HideInInspector] public List<Product> currentTasks = new List<Product>();
    int proIndex;

    // Start is called before the first frame update
    void Start()
    {
        images[0].sprite = TasksObjects[0].sprite;
        images[1].sprite = TasksObjects[1].sprite;
        images[2].sprite = TasksObjects[2].sprite;
        currentTasks.Add(TasksObjects[0]);
        currentTasks.Add(TasksObjects[1]);
        currentTasks.Add(TasksObjects[2]);
        proIndex = 3;
    }


    public void Sold(int index)
    {
        Debug.Log("sOLDOUT");
        battery.IncreaseBattery();
        if (proIndex >= TasksObjects.Length)
        {
            LevelComplete();
        }
        else
        {
            //Debug.Log(images[index]);
            images[index].sprite = TasksObjects[proIndex].sprite;
            currentTasks[index] = TasksObjects[proIndex];
            proIndex++;
        }

    }

    void LevelComplete()
    {
        Debug.Log("level bitti digerine gec");
    }
}
