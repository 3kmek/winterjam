using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string gameSceneName = "GoodEnding"; // Name of the game scene to load

    // Method to start the game
    public void StartGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene(gameSceneName); // Load the game scene
    }

    // Method to open the settings menu
    public void OpenSettings()
    {
        Debug.Log("Opening settings...");
        // Add logic to open settings UI (e.g., enable settings panel)
    }

    // Method to quit the application
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit(); // Exits the application
    }
}
