using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // �����¡�ҡ������

    public int score = 0;
    public TMP_Text scoreText; // UI ����ʴ���ṹ
    public TMP_Text loseScoreText;
    public TMP_Text winScoreText;

    void Awake()
    {
        // ��˹� instance
        instance = this;
    }

    void Start()
    {
        UpdateUI(); // �ʴ�����������
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
        if (loseScoreText != null)
        {
            loseScoreText.text = "Your Score : " + score;
        }
        if (winScoreText != null)
        {
            winScoreText.text = "Your Score : " + score;
        }
    }
}