using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObjectAli : MonoBehaviour
{
    bool isHolding = false;
    public GameObject holdingObject;
    [SerializeField] float holdRange = 3f;

    private GameObject lastHighlightedObject; // Daha önce highlight edilen obje

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Interactable tag'ine sahip bir obje tespit edildiğinde
            if (hit.transform.gameObject.CompareTag("Interactable") && Vector3.Distance(hit.transform.position, this.transform.position) < holdRange)
            {
                // Highlight (renk değişimi) uygula
                HighlightObject(hit.transform.gameObject);

                // Sol tık ile obje tutma
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    hit.transform.position = this.transform.GetChild(0).GetChild(0).transform.position;

                    // Objenin Player'a dönmesini sağla
                    RotateObjectToPlayer(hit.transform);

                    Debug.Log(hit.transform.gameObject.name);
                    hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    holdingObject = hit.transform.gameObject;
                }
            }
            else
            {
                // Highlight kaldır
                RemoveHighlight();
            }
        }
        else
        {
            // Raycast hiçbir şey bulamazsa highlight kaldır
            RemoveHighlight();
        }

        // Sol tık bırakıldığında
        if (Input.GetKeyUp(KeyCode.Mouse0) && holdingObject != null)
        {
            Debug.Log(holdingObject.name);
            holdingObject.GetComponent<Rigidbody>().isKinematic = false;
            holdingObject = null;
        }
    }

    void HighlightObject(GameObject obj)
    {
        // Zaten highlight edilmişse, tekrardan işlem yapma
        if (lastHighlightedObject == obj) return;

        // Yeni objeyi highlight et
        RemoveHighlight(); // Önceki highlight'ı kaldır
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.green; // Highlight rengi
        }
        lastHighlightedObject = obj;
    }

    void RemoveHighlight()
    {
        // Önceki objenin highlight'ını kaldır
        if (lastHighlightedObject != null)
        {
            Renderer renderer = lastHighlightedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.white; // Varsayılan renk
            }
            lastHighlightedObject = null;
        }
    }

    void RotateObjectToPlayer(Transform objTransform)
    {
        // Objenin Player'a dönük olmasını sağla
        Vector3 playerForward = this.transform.forward; // Player'ın baktığı yön
        playerForward *= -1;
        objTransform.rotation = Quaternion.LookRotation(playerForward); // Obje Player'ın yönüne bakar
    }
}
