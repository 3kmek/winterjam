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
        SceneManager.LoadScene(gameSceneName); // Load the game scene
        creditsPanel.SetActive(false);
    }


    // Method to open the credits panel
    public void OpenCredits()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true); // Show the credits panel
        }
        else
        {
        }
    }

    // Method to close the credits panel
    public void CloseCredits()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false); // Hide the credits panel
        }
        else
        {
        }
    }

    // Method to quit the application
    public void QuitGame()
    {
        Application.Quit(); // Exits the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
