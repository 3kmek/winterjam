using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dolap : MonoBehaviour
{
    [SerializeField] private GameObject LeftEl, RightEl, LeftLeg, RightLeg, Body, Head;

    [SerializeField] public int DolabaAtilan = 0;
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
                DolabaAtilan += 1;
            }

            else
            {
                other.gameObject.SetActive(false);
                RightEl.SetActive(true);
                DolabaAtilan += 1;
            }
            
        }
        
        if (other.gameObject.GetComponent<RightLeg>())
        {
            
            if (RightLeg.activeSelf)
            {
                other.gameObject.SetActive(false);
                DolabaAtilan += 1;
                LeftLeg.SetActive(true);
            }
            else
            {
                other.gameObject.SetActive(false);
                RightLeg.SetActive(true);
                DolabaAtilan += 1;
            }
        }
        
        
        if (other.gameObject.GetComponent<RightLeg>())
        {
            
            if (RightLeg.activeSelf)
            {
                other.gameObject.SetActive(false);
                DolabaAtilan += 1;
                LeftLeg.SetActive(true);
            }
            else
            {
                other.gameObject.SetActive(false);
                RightLeg.SetActive(true);
                DolabaAtilan += 1;
            }
        }
        
        
        
       
        
        if (other.gameObject.GetComponent<Head>())
        {
            other.gameObject.SetActive(false);
            Head.SetActive(true);
            DolabaAtilan += 1;
        }
        
        if (other.gameObject.GetComponent<Body>())
        {
            other.gameObject.SetActive(false);
            Body.SetActive(true);
            DolabaAtilan += 1;
        }
    }
}
