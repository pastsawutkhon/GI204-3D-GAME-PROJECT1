using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float timeLeft = 60f;
    public GameObject endCanvas;
    public TMP_Text timerText;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            EndGame();
        }

        timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString() + "s";
    }

    void EndGame()
    {
        isGameOver = true;
        timeLeft = 0;

        Time.timeScale = 0f;
        endCanvas.SetActive(true);
    }
}
