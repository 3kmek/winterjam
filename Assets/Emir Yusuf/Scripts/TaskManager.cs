using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    [SerializeField] Product[] TasksObjects;
    [SerializeField] Image[] images;
    [SerializeField] Battery battery;
    public List<Product> currentTasks = new List<Product>();
    int proIndex;
    bool notNull=false;
    
    [SerializeField] LevelManager levelManager;
    [SerializeField] Manager manager;

    [SerializeField] private GameObject level5Gb;
    
    // Start is called before the first frame update
    void Start()
    {
        switch (TasksObjects.Length)
        {
            
            case 0:
                break;
            case 1:
                images[0].sprite = TasksObjects[0].sprite;
                currentTasks.Add(TasksObjects[0]);
                images[1].enabled = false;
                images[2].enabled = false;
                break;
            case 2:
                images[1].sprite = TasksObjects[1].sprite;
                images[0].sprite = TasksObjects[0].sprite;
                currentTasks.Add(TasksObjects[0]);
                currentTasks.Add(TasksObjects[1]);
                images[2].enabled = false;
                break;
            default:
                images[0].sprite = TasksObjects[0].sprite;
                images[1].sprite = TasksObjects[1].sprite;
                images[2].sprite = TasksObjects[2].sprite;
                currentTasks.Add(TasksObjects[0]);
                currentTasks.Add(TasksObjects[1]);
                currentTasks.Add(TasksObjects[2]);
                break;

        }
        
        proIndex = 3;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        
        
    }

    private void Update()
    {
        level5Gb = GameObject.FindGameObjectWithTag("level5");
        notNull = false;
        for (int i = 0;i < currentTasks.Count; i++)
        {
            if (currentTasks[i] != null)
            {
                notNull = true;
            }
            else
            {
                images[i].gameObject.SetActive(false);
            }
        }
        if (!notNull) 
            LevelComplete();
    }
    public void Sold(int index)
    {
        battery.IncreaseBattery();
        if (!(proIndex >= TasksObjects.Length))
        {
            //Debug.Log(images[index]);
            images[index].sprite = TasksObjects[proIndex].sprite;
            currentTasks[index] = TasksObjects[proIndex];
            proIndex++;
        }
        else 
        {
            images[index].sprite = null;
            currentTasks[index] = null;
        }

    }

    void LevelComplete()
    {
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            level5Gb.GetComponent<Level5>().SonuKontrolEt();
            
        }
        else
        {
            levelManager.NextLevel();
        }
        
    }
}
