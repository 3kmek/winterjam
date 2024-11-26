using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialDialog : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject TutUI;
    public GameObject dialogBox; // The dialog box container
    public TextMeshProUGUI dialogText; // TextMesh Pro text for dialog

    [Header("Dialog Settings")]
    public string[] dialogLines; // Array of tutorial dialog lines
    public AudioClip[] voiceLines; // Array of voice clips corresponding to dialog lines
    public float typingSpeed = 0.05f; // Speed of the typewriter effect (optional)

    private int currentLineIndex = 0;
    private Coroutine typingCoroutine;
    private AudioSource audioSource;

    [SerializeField] private Battery battery;
    [SerializeField] private PlayerMovement playerMovement;
    void Start()
    {
        // Get or Add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        dialogBox.SetActive(true); // Show the dialog box at the start
        ShowDialogLine();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Skip to the next dialog line
        {
            if (typingCoroutine != null)
            {
                // If typing is in progress, complete the line instantly
                StopCoroutine(typingCoroutine);
                dialogText.text = dialogLines[currentLineIndex];
                typingCoroutine = null;

                // Ensure voice line is playing
                PlayVoiceLine(currentLineIndex);
            }
            else
            {
                ShowNextLine();
            }
        }
    }

    void ShowDialogLine()
    {
        // Start the typewriter effect
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText(dialogLines[currentLineIndex]));

        // Play voice line for this dialog line
        PlayVoiceLine(currentLineIndex);
    }

    IEnumerator TypeText(string line)
    {
        dialogText.text = ""; // Clear the dialog text
        foreach (char letter in line)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Wait before adding the next letter
        }
        typingCoroutine = null; // Typing complete
    }

    void PlayVoiceLine(int index)
    {
        if (voiceLines.Length > index && voiceLines[index] != null)
        {
            audioSource.clip = voiceLines[index];
            audioSource.Play();
        }
    }

    void ShowNextLine()
    {
        // Advance to the next dialog line or close the dialog
        currentLineIndex++;
        if (currentLineIndex < dialogLines.Length)
        {
            ShowDialogLine();
        }
        else
        {
            EndDialog();
        }
    }

    void EndDialog()
    {
        // Hide the dialog box and optionally start gameplay
        audioSource.Stop();
        dialogBox.SetActive(false);
        TutUI.SetActive(false);
        Debug.Log("Tutorial completed! Gameplay starts.");
        battery.GetComponent<Battery>().enabled = true;
        playerMovement.GetComponent<PlayerMovement>().enabled = true;
        // Enable player controls or start the main game logic here
    }
}
