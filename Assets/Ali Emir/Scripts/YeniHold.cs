using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro için

public class YeniHold : MonoBehaviour
{
    public float pickUpRange = 5f; // Etkileşim mesafesi
    public Transform holdPoint; // Objeyi tutacağımız yer
    private GameObject heldObject; // Tuttuğumuz obje
    private Rigidbody heldObjectRb; // Tuttuğumuz objenin Rigidbody'si

    // 'Hold Left Click' mesajı için TextMeshPro
    public TextMeshProUGUI holdLeftClickText;

    void Update()
    {
        // Objeleri vurgulama ve mesaj gösterme
        HandleHighlighting();

        // Sol mouse tuşuna basılıyken
        if (Input.GetMouseButton(0))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
        }
        else
        {
            if (heldObject != null)
            {
                DropObject();
            }
        }

        // Objeyi tutuyorsak, onu holdPoint'e taşı
        if (heldObject != null)
        {
            MoveHeldObject();
        }
    }

    void HandleHighlighting()
    {
        // Eğer bir obje tutuyorsak, mesajı göstermeyelim
        if (heldObject != null)
        {
            if (holdLeftClickText != null)
            {
                holdLeftClickText.gameObject.SetActive(false);
            }
            return;
        }

        // Kamera'dan mouse pozisyonuna doğru bir ray at
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                // 'Hold Left Click' mesajını göster
                if (holdLeftClickText != null)
                {
                    holdLeftClickText.gameObject.SetActive(true);
                }
            }
            else
            {
                // Mesajı gizle
                if (holdLeftClickText != null)
                {
                    holdLeftClickText.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            // Mesajı gizle
            if (holdLeftClickText != null)
            {
                holdLeftClickText.gameObject.SetActive(false);
            }
        }
    }

    void TryPickUpObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                PickUpObject(hit.collider.gameObject);

                // Mesajı gizle
                if (holdLeftClickText != null)
                {
                    holdLeftClickText.gameObject.SetActive(false);
                }
            }
        }
    }

    void PickUpObject(GameObject obj)
    {
        heldObject = obj;
        heldObjectRb = obj.GetComponent<Rigidbody>();
        if (heldObjectRb != null)
        {
            heldObjectRb.useGravity = false;
            heldObjectRb.velocity = Vector3.zero;
            heldObjectRb.angularVelocity = Vector3.zero;
        }
    }

    void MoveHeldObject()
    {
        Vector3 targetPosition = holdPoint.position;
        Vector3 direction = targetPosition - heldObject.transform.position;

        if (heldObjectRb != null)
        {
            heldObjectRb.velocity = direction * 10f; // Objeyi hızlıca hedefe taşır
        }
        else
        {
            heldObject.transform.position = targetPosition;
        }

        // Objenin karaktere doğru dönmesi
        Vector3 lookDirection = transform.position - heldObject.transform.position;
        lookDirection.y = 0; // Y ekseninde döndürme yapma
        if (lookDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            heldObject.transform.rotation = Quaternion.Slerp(heldObject.transform.rotation, rotation, Time.deltaTime * 10f);
        }
    }

    void DropObject()
    {
        if (heldObjectRb != null)
        {
            heldObjectRb.useGravity = true;
        }
        // Objenin aktifliğini kapat
        
        heldObject = null;
        heldObjectRb = null;
    }
}
