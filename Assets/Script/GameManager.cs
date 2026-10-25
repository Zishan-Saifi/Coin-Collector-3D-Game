using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public GameObject playButton;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private int totalCoins;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        
        // Game start hone par Play button dikhega, GameOver panel band rahega
        if (playButton != null) playButton.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        
        Time.timeScale = 0f; // Jab tak Play button na dabayein, game pause rahega
    }

    public void StartGame()
    {
        if (playButton != null) playButton.SetActive(false);
        Time.timeScale = 1f; // Game start ho jayega
    }

    public void AddScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (score >=totalCoins)
        {
            if (winPanel != null) winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void TriggerGameOver()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
