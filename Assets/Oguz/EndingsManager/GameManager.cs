using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public int playerScore = 0; // Example: Player's score
    public bool madeGoodChoices = false; // Example: Player's choices

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdatePlayerScore(int points)
    {
        playerScore += points;
    }

    public void SetGoodChoiceMade(bool choice)
    {
        madeGoodChoices = choice;
    }
}

