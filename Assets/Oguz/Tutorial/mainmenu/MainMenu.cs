using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string gameSceneName = "GoodEnding"; // Name of the game scene to load
    [SerializeField] private GameObject creditsPanel; // Reference to the credits panel

    // Method to start the game
    public void StartGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene(gameSceneName); // Load the game scene
        creditsPanel.SetActive(false);
    }


    // Method to open the credits panel
    public void OpenCredits()
    {
        Debug.Log("Opening credits...");
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true); // Show the credits panel
        }
        else
        {
            Debug.LogWarning("Credits panel is not assigned!");
        }
    }

    // Method to close the credits panel
    public void CloseCredits()
    {
        Debug.Log("Closing credits...");
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false); // Hide the credits panel
        }
        else
        {
            Debug.LogWarning("Credits panel is not assigned!");
        }
    }

    // Method to quit the application
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit(); // Exits the application
    }
}
