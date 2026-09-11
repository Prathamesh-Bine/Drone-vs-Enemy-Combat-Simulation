using UnityEngine;
using TMPro; // Required to use TextMeshPro UI elements

public class ScoreManager : MonoBehaviour
{
    // This creates a globally accessible instance of this script
    public static ScoreManager instance; 
    
    [SerializeField] TextMeshProUGUI scoreText;
    private int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;
    }
}