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
    public float typingSpeed = 0.05f; // Speed of the typewriter effect

    private int currentLineIndex = 0;
    private Coroutine typingCoroutine;

    void Start()
    {
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
        dialogBox.SetActive(false);
        TutUI.SetActive(false);

        Debug.Log("Tutorial completed! Gameplay starts.");
        // Enable player controls or start the main game logic here
    }
}
