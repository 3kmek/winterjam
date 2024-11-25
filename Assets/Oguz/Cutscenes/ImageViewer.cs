using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // To manage scene loading
using System.Collections;

public class ImageViewer : MonoBehaviour
{
    [Header("Image Settings")]
    [SerializeField] private Image displayImage; // The UI Image component to show images
    [SerializeField] private Sprite[] images; // Array of images to cycle through
    [SerializeField] private string mainMenuSceneName = "MainMenu"; // Name of the main menu scene

    private int currentImageIndex = 0; // Keeps track of the current image

    void Start()
    {
        if (images.Length > 0 && displayImage != null)
        {
            // Display the first image
            displayImage.sprite = images[currentImageIndex];
        }
        else
        {
            Debug.LogWarning("Please assign images and the Image component in the Inspector.");
        }
    }

    void Update()
    {
        // Check for Space key input to change the image
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextImage();
        }
    }

    private void ShowNextImage()
    {
        // Increment the index
        currentImageIndex++;

        // Check if we reached the end of the images
        if (currentImageIndex >= images.Length)
        {
            LoadMainMenu();
            return;
        }

        // Update the display image
        displayImage.sprite = images[currentImageIndex];
    }

    private void LoadMainMenu()
    {
        StartCoroutine(FadeToMainMenu());
    }

    private IEnumerator FadeToMainMenu()
    {
        // Example fade effect: Implement your actual fade logic here.
        Debug.Log("Fading to Main Menu...");
        yield return new WaitForSeconds(0.5f); // Simulate fade duration
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
