using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    // Start is called before the first frame update
    bool isHolding = false;
    public GameObject holdingObject;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Interactable"))
                {
                    hit.transform.position = this.transform.GetChild(0).transform.position;
                    Debug.Log(hit.transform.gameObject.name);
                    hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic= true;
                    holdingObject = hit.transform.gameObject;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log(holdingObject.name);
            holdingObject.GetComponent<Rigidbody>().isKinematic = false;
        }
}
    }
   
