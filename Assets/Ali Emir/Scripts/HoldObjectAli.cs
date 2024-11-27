using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoldObjectAli : MonoBehaviour
{
    bool isHolding = false;
    [SerializeField] float holdRange = 3f;
    [SerializeField] float lerpSpeed = 5f; // Lerp hızını ayarlamak için

    private GameObject lastHighlightedObject; // Daha önce highlight edilen obje
    [SerializeField] private TextMeshProUGUI interactText; // Etkileşim yazısını gösterecek TextMeshPro UI

    private Rigidbody heldObject;
    private Transform holdTransform;

    private void Start()
    { 
        holdTransform = transform.GetChild(0).GetChild(0).transform;
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        GameObject interactObject = null;
        if (Physics.Raycast(ray, out hit, holdRange))
        {
            // Interactable tag'ine sahip bir obje tespit edildiğinde
            if (hit.transform.gameObject.CompareTag("Interactable"))
            {
                interactObject = hit.transform.gameObject;
                // Highlight (renk değişimi) uygula
                HighlightObject(hit.transform.gameObject);

                // Etkileşim yazısını göster
                ShowInteractText(true);
            }
            else
            {
                // Highlight kaldır ve yazıyı gizle
                RemoveHighlight();
                ShowInteractText(false);
            }
        }
        
        if (interactObject != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            heldObject = interactObject.GetComponent<Rigidbody>();
            isHolding = true;
            
            heldObject.useGravity = false;
            heldObject.GetComponent<Collider>().enabled = false;
        }
        
        if (isHolding && heldObject != null)
        {
            if (Input.GetMouseButtonUp(0) || Vector3.Distance(transform.position, heldObject.transform.position) > holdRange * 2)
            {
                isHolding = false;
                heldObject.useGravity = true;
                heldObject.GetComponent<Collider>().enabled = true;
                heldObject = null;
            }
            else
            {
                var newPosition= Vector3.Lerp(heldObject.transform.position, holdTransform.position,
                    Time.deltaTime * lerpSpeed);
                var dir = (newPosition - transform.position).normalized;
                if (Physics.Raycast(heldObject.transform.position, dir, out hit, 2f))
                {
                    return;
                }
                heldObject.position = newPosition;

                // Objenin Player'a dönmesini sağla
                RotateObjectToPlayer(heldObject.transform);
            
                // Etkileşim yazısını gizle (artık objeyi tutuyoruz)
                ShowInteractText(false);
            }
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

    void ShowInteractText(bool show)
    {
        if (interactText != null)
        {
            interactText.gameObject.SetActive(show); // TextMeshPro objesini aktif/pasif yap
        }
    }
}
