using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DolapAnim : MonoBehaviour
{
    public Animator leverAnimator; // Lever'ın animatoru
    public TextMeshProUGUI interactText; // "Hold E" yazısı için UI Text
    public Transform player; // Oyuncunun transformu
    public float interactionDistance = 6f; // Lever'a yaklaşma mesafesi
    private bool isPlayerNearby = false; // Oyuncu lever yakınında mı?
    private bool isLookingAtLever = false; // Oyuncu lever'a mı bakıyor?
    
    // Start is called before the first frame update
    void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false); // Başta yazıyı gizle
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        // Oyuncu lever'a yakın mı?
        isPlayerNearby = distance <= interactionDistance;

        if (isPlayerNearby)
        {
            // Oyuncunun bakış yönü
            Vector3 directionToLever = (transform.position - player.position).normalized;
            float dotProduct = Vector3.Dot(player.forward, directionToLever);

            // Oyuncu lever'a doğru bakıyor mu?
            isLookingAtLever = dotProduct > 0.5f; // Bakış açısı kontrolü

            if (isLookingAtLever)
            {
                
                interactText.gameObject.SetActive(true); // "Hold E" yazısını göster
                leverAnimator.SetTrigger("DolapPull");
                leverAnimator.ResetTrigger("DolapNotPull");
                
            }
            else
            {
                interactText.gameObject.SetActive(false); // Yazıyı gizle
                leverAnimator.ResetTrigger("DolapPull");
            }
        }
        else
        {
            leverAnimator.ResetTrigger("DolapPull");
            leverAnimator.SetTrigger("DolapNotPull");
            interactText.gameObject.SetActive(false); // Yazıyı gizle
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        // Interaction mesafesi için bir daire çiz
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
