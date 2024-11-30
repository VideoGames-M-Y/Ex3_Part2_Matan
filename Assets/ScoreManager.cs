// using UnityEngine;
// using TMPro;  // Make sure to include this namespace for TextMeshPro

// public class ScoreManager : MonoBehaviour
// {
//     public TextMeshProUGUI scoreText;  // This should be TextMeshProUGUI
//     private int score = 0;  // Starting score

//     // Method to start the score
//     public void Start()
//     {
//         scoreText.text = "Score: " + score.ToString();  // Set the initial score text
//     }

//     // Method to update the score
//     public void UpdateScore(int amount)
//     {
//         score += amount;
//         scoreText.text = "Score: " + score.ToString();  // Update the text to show the score
//     }
// }

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Singleton instance
    public static ScoreManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;  // Reference to the UI TextMeshPro element to display the score
    private int score = 0;  // Score will be initialized only if it's not already set

    // private void Awake()
    // {
    //     // If an instance of ScoreManager already exists, destroy the new one
    //     if (Instance != null && Instance != this)
    //     {
    //         Destroy(gameObject);  // Destroy the duplicate instance
    //         return;
    //     }

    //     // Set the Singleton instance and ensure it persists across scenes
    //     Instance = this;
    //     DontDestroyOnLoad(gameObject);  // Make sure this object is not destroyed when changing scenes

    //     // Initialize the score only if it's not already set (to keep the score across scenes)
    //     if (scoreText != null)
    //     {
    //         if (score == 0) // Only initialize the score if it's still at the default (0)
    //         {
    //             score = PlayerPrefs.GetInt("score", 0); // Load score from PlayerPrefs, default to 0
    //         }

    //         // Update the score UI text
    //         scoreText.text = "Score: " + score.ToString();
    //     }
    // }

    private void Awake()
{
    // If an instance of ScoreManager already exists, destroy the new one
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);  // Destroy the duplicate instance
        return;
    }

    // Set the Singleton instance and ensure it persists across scenes
    Instance = this;
    DontDestroyOnLoad(gameObject);  // Make sure this object is not destroyed when changing scenes

    // Initialize the score only if it's not already set (to keep the score across scenes)
    if (scoreText != null)
    {
        // If we are in the StartScene, reset the score
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            ResetScore();
        }
        else
        {
            score = PlayerPrefs.GetInt("score", 0); // Load score from PlayerPrefs, default to 0
        }

        // Update the score UI text
        scoreText.text = "Score: " + score.ToString();
    }
}

    // Method to update the score
    public void UpdateScore(int amount)
    {
        score += amount;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();  // Update the score text in the UI
        }

        // Save the updated score using PlayerPrefs to persist across scenes
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    // Method to reset the score (optional)
    public void ResetScore()
    {
        score = 0;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();  // Reset the score text display
        }

        // Save the reset score
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }
}

