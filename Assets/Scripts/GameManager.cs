using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float timeLeft = 60f;
    public GameObject endCanvas;
    public GameObject winCanvas;
    public GameObject gameCanvas;
    public TMP_Text timerText;
    

    private bool isGameOver = false;

    void Awake()
    {
        endCanvas.SetActive(false);
        winCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        
    }
    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            EndGame();
        }

        timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString() + "s";
        
        if(ScoreManager.instance.score >= 100)
        {
            Invoke(nameof(WinGame), 1f);
        }
    }

    void EndGame()
    {
        isGameOver = true;
        timeLeft = 0;
        gameCanvas.SetActive(false);
        Time.timeScale = 0f;
        endCanvas.SetActive(true);
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void WinGame()
    {
        isGameOver = true;
        timeLeft = 0;
        gameCanvas.SetActive(false);
        Time.timeScale = 0f;
        winCanvas.SetActive(true);
    }
}
