using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject gameOverPanel;
    public GameObject winPanel;

    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!gameEnded)
        {
            CheckWinCondition();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        if (gameEnded) return;

        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        gameEnded = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        HideGameObjects();

        Time.timeScale = 0f;
    }

    void CheckWinCondition()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        if (bricks.Length == 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        HideGameObjects();

        Time.timeScale = 0f;
    }

    void HideGameObjects()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            ball.SetActive(false);
        }

        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        if (paddle != null)
        {
            paddle.SetActive(false);
        }

        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        foreach (GameObject brick in bricks)
        {
            brick.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}