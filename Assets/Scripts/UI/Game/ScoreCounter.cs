using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    private static int Score;
    private static int HighScore;

    [SerializeField] private Text scoreText;

    private void Start() {
        GlobalEventManager.OnEnemyKilledEvent += IncreaseScore;
        GlobalEventManager.OnEnemyTouchedWallEvent += DecreaseScore;
        GlobalEventManager.OnPlayerDiedEvent += SaveHighScore;
        int HighScore = PlayerPrefs.GetInt("HighScore");
        scoreText = GetComponent<Text>();
        Score = 0;
    }

    private void IncreaseScore(int ToAdd) {
        Score += ToAdd;
        UpdateUI();
    }

    private void DecreaseScore() {
        if (Score > 0)
            Score -= 1;
        UpdateUI();
    }

    private void UpdateUI() {
        scoreText.text = $"{Score}";
    }

    public static int GetScore() => Score;

    public static int GetHighScore() => PlayerPrefs.GetInt("HighScore");

    public static void SaveHighScore() {
        if (Score > HighScore)
            PlayerPrefs.SetInt("HighScore", Score);
    }

    private void OnDestroy() 
    {
        GlobalEventManager.OnEnemyKilledEvent -= IncreaseScore;
        GlobalEventManager.OnEnemyTouchedWallEvent -= DecreaseScore;
        GlobalEventManager.OnPlayerDiedEvent -= SaveHighScore;
    }
}