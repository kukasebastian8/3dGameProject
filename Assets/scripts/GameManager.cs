using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Using TextMesh Pro for the UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance for global access
    public int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // This should match the component type used in Unity (TextMeshProUGUI for UI text)
    
    private int totalTargets = 0; // Total number of targets in the current scene
    private int targetsHit = 0; // Counter for the number of targets hit

    void Awake()
    {
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

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetGameState();
        AssignScoreText();
        CountTargets(); // Count targets again whenever a new scene is loaded
    }

    void AssignScoreText()
    {
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            if (scoreText == null)
            {
                Debug.LogError("TextMeshProUGUI component not found on the object tagged as 'ScoreText'. Please add it.");
            }
            else
            {
                UpdateScoreUI(); // Update score immediately to reflect the initial state.
            }
        }
        else
        {
            Debug.LogWarning("No GameObject found with the tag 'ScoreText' in this scene.");
        }
    }

    public void AddScore(int amount)
    {
        if (targetsHit < totalTargets)
        {
            score += amount;
            targetsHit++;
            UpdateScoreUI();
            CheckCompletion();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void CheckCompletion()
    {
        if (targetsHit >= totalTargets)
        {
            Debug.Log("All targets hit. Returning to SampleScene...");
            Invoke("LoadSampleScene", 2); // Adds a delay of 2 seconds before loading the sample scene
        }
    }

    void ResetGameState()
    {
        score = 0;
        targetsHit = 0;
        UpdateScoreUI();
    }

    void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void CountTargets()
    {
        totalTargets = FindObjectsOfType<TargetHitDetection>().Length;
        Debug.Log("Total targets in the scene: " + totalTargets);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
