using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // Singleton instance
    [SerializeField] private TextMeshProUGUI scoreText; // Assign in the Inspector
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore(int points)
    {
        score += points;
        UpdateScoreText();
        Debug.Log("Score incremented to: " + score);
    }

    public void DecrementScore(int points)
    {
        if (score > 0)
        {
            score -= points;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogError("ScoreText not assigned in ScoreManager.");
    }
}
