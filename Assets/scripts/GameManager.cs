
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject zenModeButton;
    public TMP_Text scoreText;
    public TMP_Text energyText;

    private float score;
    private bool isGameOver;
    private bool isPaused = false;

    public int zenEnergy = 0;
    public int maxZenEnergy = 100;

    public float zenModeDuration = 5f;
    public float slowMotionScale = 0.5f;

    private bool isZenModeActive = false;

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScore();
    }

    public void AddZenEnergy(int amount)
    {
        if (isGameOver) return;

        zenEnergy = Mathf.Clamp(
            zenEnergy + amount, 0, maxZenEnergy
        );

        UpdateEnergy();
    }

    private System.Collections.IEnumerator ZenModeCoroutine()
    {
        isZenModeActive = true;

        Time.timeScale = slowMotionScale;

        yield return new WaitForSecondsRealtime(zenModeDuration);

        Time.timeScale = 1f;
        isZenModeActive = false;
    }

    public void ActivateZenMode()
    {
        if (isGameOver || isPaused) return;
        if (zenEnergy < maxZenEnergy) return;
        if (isZenModeActive) return;

        zenEnergy = 0;
        UpdateEnergy();

        StartCoroutine(ZenModeCoroutine());
    }

    void Start()
    {
        Time.timeScale = 1f;
        score = 0f;
        zenEnergy = 0;
        isGameOver = false;
        isPaused = false;

        UpdateScore();
        UpdateEnergy();
    }

    void Update()
    {
        if (isGameOver || isPaused) return;

        score += Time.deltaTime;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " +
                Mathf.FloorToInt(score);
        }
    }

    void UpdateEnergy()
    {
        if (energyText != null)
        {
            energyText.text = "Zen Energy: " +
                zenEnergy + " / " + maxZenEnergy;
        }

        if (zenModeButton != null)
        {
            zenModeButton.SetActive(zenEnergy >= maxZenEnergy);
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
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void PauseGame()
    {
        if (isGameOver) return;

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
