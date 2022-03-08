using UnityEngine.UI;
using UnityEngine;

public class ScoreCouner : MonoBehaviour
{
    private int Score;

    private Text scoreText;

    private void Start()
    {
        GlobalEventManager.OnEnemyKilledEvent += AddScore;
        scoreText = GetComponent<Text>();
    }

    private void AddScore(int ToAdd)
    {
        Score += ToAdd;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + Score;
    }
}
