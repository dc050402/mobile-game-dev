using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public TMP_Text scoreText;

    private float score;
    private bool isGameOver;
    private bool isPaused = false;

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }


    void Start()
    {
        Time.timeScale = 1f;
        score = 0f;
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
}
}