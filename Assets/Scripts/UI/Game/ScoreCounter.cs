using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    private static int Score;
    private static int HighScore;
    public static int HumansAmount;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject humansTextGO;
    private Text _humansText;
    private Animator _textAnimator;

    private void Start() {
        GlobalEvents.OnEnemyKilledEvent += IncreaseScore;
        GlobalEvents.OnEnemyTouchedWallEvent += DecreaseScore;
        GlobalEvents.OnPlayerDiedEvent += SaveProgress;

        Score = 0;

        HighScore = PlayerPrefs.GetInt("HighScore");
        HumansAmount = PlayerPrefs.GetInt("Humans");

        scoreText = GetComponent<Text>();
        _humansText = humansTextGO.GetComponent<Text>();
        _textAnimator = humansTextGO.GetComponent<Animator>();
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
            ShowAchieve();
        }
    }

    private void UpdateUI() {
        scoreText.text = $"{Score}";
    }

    private void ShowAchieve() {
        _humansText.text = $"You've killed {HumansAmount} humans";
        _textAnimator.SetTrigger("IsComplete");
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
        GlobalEvents.OnEnemyKilledEvent -= IncreaseScore;
        GlobalEvents.OnEnemyTouchedWallEvent -= DecreaseScore;
        GlobalEvents.OnPlayerDiedEvent -= SaveProgress;
    }
}