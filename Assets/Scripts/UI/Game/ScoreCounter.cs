using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private static int Score;

    private Text scoreText;

    private void Start()
    {
        GlobalEventManager.OnEnemyKilledEvent += IncreaseScore;
        GlobalEventManager.OnEnemyTouchedWallEvent += DecreaseScore;
        scoreText = GetComponent<Text>();
    }

    private void IncreaseScore(int ToAdd)
    {
        Score += ToAdd;
        UpdateUI();
    }

    private void DecreaseScore()
    {
        if(Score>0)
        Score -= 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + Score;
    }

    public static int GetScore() => Score;
}
