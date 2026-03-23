using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // ใช้เรียกจากที่อื่น

    public int score = 0;
    public TMP_Text scoreText; // UI ที่แสดงคะแนน

    void Awake()
    {
        // กำหนด instance
        instance = this;
    }

    void Start()
    {
        UpdateUI(); // แสดงค่าเริ่มต้น
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }
}