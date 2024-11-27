using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoldObjectEskiAli : MonoBehaviour
{
    bool isHolding = false;
    public GameObject holdingObject;
    [SerializeField] float holdRange = 3f;

    private GameObject lastHighlightedObject; // Daha önce highlight edilen obje
    [SerializeField] private TextMeshProUGUI interactText; // Etkileşim yazısını gösterecek TextMeshPro UI

    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>(); // Objelerin orijinal renkleri

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Interactable tag'ine sahip bir obje tespit edildiğinde
            if (hit.transform.gameObject.CompareTag("Interactable") && Vector3.Distance(hit.transform.position, this.transform.position) < holdRange)
            {
                HighlightObject(hit.transform.gameObject);

                // Etkileşim yazısını göster
                ShowInteractText(true);

                // Sol tık ile obje tutma
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    hit.transform.position = this.transform.GetChild(0).GetChild(0).transform.position;
                    isHolding = true;
                    RotateObjectToPlayer(hit.transform);

                    hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    holdingObject = hit.transform.gameObject;

                    // Etkileşim yazısını gizle
                    ShowInteractText(false);
                }
            }
            else
            {
                // Highlight kaldır ve yazıyı gizle
                RemoveHighlight();
                ShowInteractText(false);
            }
        }
        else
        {
            // Raycast hiçbir şey bulamazsa highlight kaldır ve yazıyı gizle
            RemoveHighlight();
            ShowInteractText(false);
        }

        // Sol tık bırakıldığında
        if (Input.GetKeyUp(KeyCode.Mouse0) && holdingObject != null)
        {
            holdingObject.GetComponent<Rigidbody>().isKinematic = false;
            holdingObject = null;
        }
    }

    void HighlightObject(GameObject obj)
    {
        // Zaten highlight edilmişse, tekrardan işlem yapma
        if (lastHighlightedObject == obj) return;

        RemoveHighlight(); // Önceki highlight'ı kaldır

        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Objeyi daha önce highlight etmediysen orijinal rengini sakla
            if (!originalColors.ContainsKey(obj))
            {
                originalColors[obj] = renderer.material.color;
            }

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
            if (renderer != null && originalColors.ContainsKey(lastHighlightedObject))
            {
                renderer.material.color = originalColors[lastHighlightedObject]; // Objeyi orijinal rengine döndür
            }
            lastHighlightedObject = null;
        }
    }

    void RotateObjectToPlayer(Transform objTransform)
    {
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
