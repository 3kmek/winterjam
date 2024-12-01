using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    public Animator leverAnimator; // Lever'ın animatoru
    public TextMeshProUGUI interactText; // "Hold E" yazısı için UI Text
    public Transform player; // Oyuncunun transformu
    public float interactionDistance = 3f; // Lever'a yaklaşma mesafesi
    private bool isPlayerNearby = false; // Oyuncu lever yakınında mı?
    private bool isLookingAtLever = false; // Oyuncu lever'a mı bakıyor?
    [SerializeField] private GameObject battery;
    [SerializeField] GameObject kardes;


    private GameObject belt;

    void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false); // Başta yazıyı gizle
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, kardes.transform.position);

        // Oyuncu lever'a yakın mı?
        isPlayerNearby = distance <= interactionDistance;

        if (isPlayerNearby)
        {
            // Oyuncunun bakış yönü
            Vector3 directionToLever = (kardes.transform.position - player.position).normalized;
            float dotProduct = Vector3.Dot(player.forward, directionToLever);

            // Oyuncu lever'a doğru bakıyor mu?
            isLookingAtLever = dotProduct > 0.5f; // Bakış açısı kontrolü

            if (isLookingAtLever)
            {
                
                
                    interactText.gameObject.SetActive(true); // "Hold E" yazısını göster
                    
                    if (Input.GetKeyDown(KeyCode.E)) // E tuşuna basıldığında
                    {
                        leverAnimator.SetTrigger("Pull"); // Pull triggerını tetikle
                        interactText.gameObject.SetActive(false); // Yazıyı gizle
                        belt = GameObject.FindGameObjectWithTag("Belt");
                        belt.GetComponent<ConveyorBelt>().Pulled();
                        battery.GetComponent<Battery>().DecreaseBattery();
                    }
                

            
            }
            else
            {
                interactText.gameObject.SetActive(false); // Yazıyı gizle
            }
        }
        else
        {
            interactText.gameObject.SetActive(false); // Yazıyı gizle
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Interaction mesafesi için bir daire çiz
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(kardes.transform.position, interactionDistance);
    }
}
