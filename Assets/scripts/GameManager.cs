using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance
    public int score = 0; // Player's score
    public Text scoreText; // Reference to the Text UI component

    private void Awake() 
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the GameManager active across scenes
        }
        else 
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }
    }

    public void AddScore(int amount) 
    {
        score += amount; // Increase the score
        UpdateScoreUI(); // Update the UI to reflect the new score
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the UI text
        }
    }
}
