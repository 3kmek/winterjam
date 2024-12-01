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
    
    private Material lastHighlightedMaterial;
    private float originalScale = 1.0f;
    private List<MeshRenderer> modifiedRenderers = new List<MeshRenderer>();

    [SerializeField] private float
    scaleAmount = 1.03f;
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
        if (hit.transform.CompareTag("Interactable"))
        {
            holdLeftClickText.gameObject.SetActive(true);
            MeshRenderer renderer = hit.transform.GetComponent<MeshRenderer>();
            if (renderer != null && renderer.materials.Length > 1)
            {
                Material material = renderer.materials[1];
                if (material != null)
                {
                    // Daha önce bir materyal vurgulandıysa eski haline döndür
                    if (lastHighlightedMaterial != null && lastHighlightedMaterial != material)
                    {
                        ResetMaterialScale(lastHighlightedMaterial);
                    }

                    // Yeni materyalin scale'ini değiştir
                    if (material.HasProperty("_Scale"))
                    {
                        material.SetFloat("_Scale", scaleAmount);
                        lastHighlightedMaterial = material; // Şu anki materyali kaydetRR
                    }

                    // Mesajı göster
                    if (holdLeftClickText != null)
                    {
                        holdLeftClickText.gameObject.SetActive(true);
                    }
                }
            }

            if (renderer == null && hit.transform.childCount > 0)
            {
                ResetAllModifiedRenderers();
                for (int i = 0;  hit.transform.childCount > i; i++)
                {
                    Transform child = hit.transform.GetChild(i);
                    MeshRenderer childRenderer = child.GetComponent<MeshRenderer>();

                    if (childRenderer != null && childRenderer.materials.Length > 0)
                    {
                        // Daha önce scale'i değiştirilmişse yeniden ekleme
                        if (!modifiedRenderers.Contains(childRenderer))
                        {
                            modifiedRenderers.Add(childRenderer); // Listeye ekle
                        }

                        // Scale'i değiştir
                        foreach (var material in childRenderer.materials)
                        {
                            if (material.HasProperty("_Scale"))
                            {
                                material.SetFloat("_Scale", scaleAmount);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            // Eğer ray başka bir şey vurursa, önceki materyalin scale'ini sıfırla
            if (lastHighlightedMaterial != null)
            {
                ResetMaterialScale(lastHighlightedMaterial);
                ResetAllModifiedRenderers();
                lastHighlightedMaterial = null; // Vurgulanan materyali sıfırla
            }

            if (modifiedRenderers != null)
            {
                ResetAllModifiedRenderers();
            }

            // Mesajı gizle
            if (holdLeftClickText != null)
            {
                holdLeftClickText.gameObject.SetActive(false);
            }
        }
    }
    else
    {
        // Eğer ray hiçbir şey vurmazsa, önceki materyalin scale'ini sıfırla
        if (lastHighlightedMaterial != null)
        {
            ResetMaterialScale(lastHighlightedMaterial);
            lastHighlightedMaterial = null; // Vurgulanan materyali sıfırla
        }

        // Mesajı gizle
        if (holdLeftClickText != null)
        {
            holdLeftClickText.gameObject.SetActive(false);
        }
    }
}
    
    void ResetMaterialScale(Material material)
    {
        if (material.HasProperty("_Scale"))
        {
            material.SetFloat("_Scale", originalScale);
        }
    }
    void ResetAllModifiedRenderers()
    {
        // Listeyi döngüyle gez ve scale'leri sıfırla
        foreach (var renderer in modifiedRenderers)
        {
            foreach (var material in renderer.materials)
            {
                if (material.HasProperty("_Scale"))
                {
                    material.SetFloat("_Scale", 1.0f); // Default scale'e dön
                }
            }
        }

        // Listeyi temizle
        modifiedRenderers.Clear();
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
