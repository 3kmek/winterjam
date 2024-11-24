using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organic : MonoBehaviour
{
    [SerializeField] public int OcagaAtılan = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LEl>())
        {
            other.gameObject.SetActive(false);
            OcagaAtılan +=1 ;
        }
        
        if (other.gameObject.GetComponent<REl>())
        {
            other.gameObject.SetActive(false);
            OcagaAtılan +=1 ;
        }
        
        if (other.gameObject.GetComponent<RightLeg>())
        {
            other.gameObject.SetActive(false);
            OcagaAtılan +=1 ;
        }
        
        if (other.gameObject.GetComponent<LeftLeg>())
        {
            other.gameObject.SetActive(false);
            OcagaAtılan +=1 ;
        }
    }
}
