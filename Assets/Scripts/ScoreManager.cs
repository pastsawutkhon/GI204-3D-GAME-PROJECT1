using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        // ทำให้เรียกใช้ได้จากที่อื่น
        instance = this;
    }

    void Start()
    {
        UpdateUI(); // เริ่มต้นให้โชว์ 0
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score : " + score;
    }
}