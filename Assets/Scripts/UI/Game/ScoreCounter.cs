using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    private static int Score;
    private static int HighScore;
    private static int HumansAmount;

    [SerializeField] private Text scoreText;

    private void Start() {
        GlobalEventManager.OnEnemyKilledEvent += IncreaseScore;
        GlobalEventManager.OnEnemyTouchedWallEvent += DecreaseScore;
        GlobalEventManager.OnPlayerDiedEvent += SaveProgress;

        HighScore = PlayerPrefs.GetInt("HighScore");
        scoreText = GetComponent<Text>();

        Score = 0;
        HumansAmount = PlayerPrefs.GetInt("Humans");
    }

    private void IncreaseScore(int ToAdd) {
        Score += ToAdd;
        IncreaseHumans();
        UpdateUI();
    }

    private void DecreaseScore() {
        if (Score > 0)
            Score -= 1;
        UpdateUI();
    }

    private void IncreaseHumans() {
        HumansAmount++;
        if (HumansAmount % 50 == 0) {

        }
    }

    private void UpdateUI() {
        scoreText.text = $"{Score}";
    }

    public static int GetScore() => Score;

    public static int GetHighScore() => PlayerPrefs.GetInt("HighScore");

    public static void SaveProgress() {
        SaveHighScore();
        SaveHumansAmount();
    }

    private static void SaveHighScore() {
        if (Score > HighScore)
            PlayerPrefs.SetInt("HighScore", Score);
    }

    private static void SaveHumansAmount() {
        PlayerPrefs.SetInt("Humans", HumansAmount);
    }

    private void OnDestroy() 
    {
        GlobalEventManager.OnEnemyKilledEvent -= IncreaseScore;
        GlobalEventManager.OnEnemyTouchedWallEvent -= DecreaseScore;
        GlobalEventManager.OnPlayerDiedEvent -= SaveProgress;
    }
}