using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    [SerializeField] private Rigidbody objectRb;
    //private var rigidbodyPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigidbodyPosition = objectRb.position;

    }
}
