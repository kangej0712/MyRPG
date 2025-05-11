using UnityEngine;
using TMPro;  // TextMeshPro ����� ���� �߰�

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;  // TextMeshProUGUI�� ����

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
