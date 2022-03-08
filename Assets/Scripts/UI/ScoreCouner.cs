using UnityEngine.UI;
using UnityEngine;

public class ScoreCouner : MonoBehaviour
{
    private int Score;

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
}
