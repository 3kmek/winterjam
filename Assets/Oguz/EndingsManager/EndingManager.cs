using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public string goodEndingScene = "GoodEnding"; // Name of the good ending scene
    public string badEndingScene = "BadEnding"; // Name of the bad ending scene

    public void EvaluateEnding()
    {
        // Example condition for good or bad ending
        if (GameManager.Instance.playerScore >= 100 && GameManager.Instance.madeGoodChoices)
        {
            LoadGoodEnding();
        }
        else
        {
            LoadBadEnding();
        }
    }

    void LoadGoodEnding()
    {
        SceneManager.LoadScene(goodEndingScene);
    }

    void LoadBadEnding()
    {
        SceneManager.LoadScene(badEndingScene);
    }
}
