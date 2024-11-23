using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLimit : MonoBehaviour
{
    //[SerializeField] private GameObject yLimit;

    private float m_limit = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= m_limit)
        {
            Vector3 newPosition = transform.position; // Pozisyonu bir değişkene al
            newPosition.y = m_limit; // Y eksenini düzenle
            transform.position = newPosition; // Yeni pozisyonu geri ata
        }
        
        
        
        
        
    }

}
