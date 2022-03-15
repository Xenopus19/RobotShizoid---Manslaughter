using UnityEngine.UI;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] string[] PossibleDeathMassages;

    [Header("UI Elements")]
    [SerializeField] private Text DeathMassageText;
    [SerializeField] private Text Score;
    [SerializeField] private Text BestScore;
    [SerializeField] private GameObject NewBest;

    private void Start()
    {
        GlobalEventManager.OnPlayerDiedEvent += SetDeathScreen;
        gameObject.SetActive(false);
    }

    private void SetDeathScreen()
    {
        gameObject.SetActive(true);
        GenerateDeathMessage();
        SetScoreText();
    }

    private void GenerateDeathMessage()
    {
        DeathMassageText.text = PossibleDeathMassages[Random.Range(0, PossibleDeathMassages.Length - 1)];
    }
    private void SetScoreText()
    {
        int ScoreValue = ScoreCounter.GetScore();
        int BestScoreValue = 1;                                           //затычка
        Score.text = "Score: " + ScoreValue;
        BestScore.text = "Best Score: " + BestScoreValue;

        if (ScoreValue > BestScoreValue)
            NewBest.SetActive(true);
    }
}
