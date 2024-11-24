using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            GameManager.Instance.UpdatePlayerScore(100);
            FindObjectOfType<EndingManager>().EvaluateEnding();
        }
    }
}
