using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tezgah : MonoBehaviour
{
    [SerializeField] private Animator animator;

    
    
    [SerializeField] TaskManager taskManager;
    List<GameObject> deliveries = new List<GameObject>();
    [SerializeField] bool isClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            animator.SetTrigger("Transfer");
            Sell(other.gameObject);
            //other.gameObject.SetActive(false);
            
        }
    }
    
    void Sell(GameObject go)
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
    
    int Index(List<Product> lst, Product itm)
    {
        //Debug.Log("Indexteyiz");
        for (int i = 0; i < lst.Count; i++)
        {
            if (lst[i].NAME == itm.NAME)
            {
                Debug.Log(i);
                return i;
            }
        }
        return -1;
    }
}
