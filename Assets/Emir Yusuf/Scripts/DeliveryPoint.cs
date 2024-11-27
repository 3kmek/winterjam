using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    List<GameObject> deliveries = new List<GameObject>();
    [SerializeField] bool isClosed = false;

    // Update is called once per frame
    void Update()
    {
        if (isClosed)
        {
            Sell();
            isClosed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            deliveries.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            deliveries.Remove(other.gameObject);
        }
    }

    void Sell()
    {
        foreach (GameObject go in deliveries)
        {
            if (go)
            {
                int i = Index(taskManager.currentTasks, go.GetComponent<Product>());
                if (i>=0)
                {  
                    taskManager.Sold(i);
                    Destroy(go);
                }
                else
                {

                    Destroy(go);
                }
            }
            
            
        }
        deliveries.Clear();
    }


    int Index(List<Product> lst, Product itm)
    {
        //Debug.Log("Indexteyiz");
        for (int i = 0; i < lst.Count; i++)
        {
            if (lst[i].NAME == itm.NAME)
            {
                return i;
            }
        }
        return -1;
    }


    void CloseTheCover()
    {
        isClosed = true;
    }
}
