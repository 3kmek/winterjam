using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dolap : MonoBehaviour
{
    [SerializeField] private GameObject LeftEl, RightEl, LeftLeg, RightLeg;

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
        if (other.gameObject.GetComponent<LEl>())
        {
            other.gameObject.SetActive(false);
            LeftEl.SetActive(true);
            DolabaAtilan += 1;
        }
        
        if (other.gameObject.GetComponent<REl>())
        {
            other.gameObject.SetActive(false);
            RightEl.SetActive(true);
            DolabaAtilan += 1;
        }
        
        if (other.gameObject.GetComponent<RightLeg>())
        {
            other.gameObject.SetActive(false);
            RightLeg.SetActive(true);
            DolabaAtilan += 1;
        }
        
        if (other.gameObject.GetComponent<LeftLeg>())
        {
            other.gameObject.SetActive(false);
            LeftLeg.SetActive(true);
            DolabaAtilan += 1;
        }
    }
}
