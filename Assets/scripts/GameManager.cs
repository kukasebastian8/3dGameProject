using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance
    public int score = 0; // Player's score
    public Text scoreText; // Reference to the Text UI component

    private int startingScoreInLevel1 = 0; // Tracks the score at the start of Level1
    private const int scoreThreshold = 1000; // Points needed to reload SampleScene

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

    private void Start()
    {
        AssignScoreText(); // Assign scoreText in the current scene
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to prevent memory leaks
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignScoreText(); // Reassign scoreText for the new scene

        // If the current scene is Level1, record the starting score
        if (scene.name == "Level1")
        {
            startingScoreInLevel1 = score;
        }
    }

    private void AssignScoreText()
    {
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<Text>();
            UpdateScoreUI();
        }
        else
        {
            Debug.LogWarning("No ScoreText object found in the current scene.");
        }
    }

    public void AddScore(int amount)
    {
        score += amount; // Increase the score
        UpdateScoreUI();

        // Check if score threshold is met in Level1
        CheckScoreThreshold();
    }

    private void CheckScoreThreshold()
    {
        // If in Level1 and the threshold is reached, reload SampleScene
        if (SceneManager.GetActiveScene().name == "Level1" && score - startingScoreInLevel1 >= scoreThreshold)
        {
            ReloadSampleScene();
        }
    }

    private void ReloadSampleScene()
    {
        Debug.Log("Score threshold reached! Reloading SampleScene...");
        SceneManager.LoadScene("SampleScene");
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

}