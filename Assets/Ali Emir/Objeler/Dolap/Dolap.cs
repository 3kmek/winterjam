using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dolap : MonoBehaviour
{
    [SerializeField] private GameObject LeftEl, RightEl, LeftLeg, RightLeg, Body, Head;

    [SerializeField] public int DolabaAtilan = 0;

    [SerializeField] public Manager Manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.GetComponent<REl>())
        {
            if (RightEl.activeSelf)
            {
                other.gameObject.SetActive(false);
                LeftEl.SetActive(true);
                PuanManager.iyiPuan += 1;
            }

            else
            {
                other.gameObject.SetActive(false);
                RightEl.SetActive(true);
                PuanManager.iyiPuan += 1;
            }
            
        }
        
        
        
        
        if (other.gameObject.GetComponent<RightLeg>())
        {
            
            if (RightLeg.activeSelf)
            {
                other.gameObject.SetActive(false);
                PuanManager.iyiPuan += 1;
                LeftLeg.SetActive(true);
            }
            else
            {
                other.gameObject.SetActive(false);
                RightLeg.SetActive(true);
                PuanManager.iyiPuan += 1;
            }
        }
        
        
        
       
        
        if (other.gameObject.GetComponent<Head>())
        {
            other.gameObject.SetActive(false);
            Head.SetActive(true);
            PuanManager.iyiPuan += 1;
        }
        
        if (other.gameObject.GetComponent<Body>())
        {
            other.gameObject.SetActive(false);
            Body.SetActive(true);
            PuanManager.iyiPuan += 1;
        }
    }
    
    
    
}
