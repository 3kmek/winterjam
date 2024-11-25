using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organic : MonoBehaviour
{
    [SerializeField] public int OcagaAtılan = 0;
    [SerializeField] public Manager Manager;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<REl>())
        {
            other.gameObject.SetActive(false);
            PuanManager.kotuPuan += 1;
        }
        
        if (other.gameObject.GetComponent<RightLeg>())
        {
            other.gameObject.SetActive(false);
            PuanManager.kotuPuan += 1;
        }
        
        if (other.gameObject.GetComponent<Head>())
        {
            other.gameObject.SetActive(false);
            PuanManager.kotuPuan += 1; ;
        }
        if (other.gameObject.GetComponent<Body>())
        {
            other.gameObject.SetActive(false);
            PuanManager.kotuPuan += 1;
        }
    }
}
