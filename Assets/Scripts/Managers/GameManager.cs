using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Score;
using System.Collections.Generic; // Import HighestScore

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public TMP_Text winScoreText;
    public TMP_Text gameOverScoreText;
    private bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        PlayerController player = FindFirstObjectByType<PlayerController>();
        if (player != null && gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + player.score;
            HighestScore.SaveHighScore(player.score); // Cập nhật điểm cao nhất
        }
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
        PlayerController player = FindFirstObjectByType<PlayerController>();
        if (player != null && winScoreText != null)
        {
            winScoreText.text = "Score: " + player.score;
            HighestScore.SaveHighScore(player.score); // Cập nhật điểm cao nhất
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log($"Next level is: {nextSceneIndex}!");
        }
        else
        {
            Debug.Log("No more levels!");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    
}
