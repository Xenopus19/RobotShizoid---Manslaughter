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

    private int wallTouchScore = 1;

    private void Start() {
        GlobalEvents.OnEnemyKilledEvent += IncreaseScore;
        GlobalEvents.OnEnemyTouchedWallEvent += DecreaseScore;
        GlobalEvents.OnPlayerDiedEvent += SaveProgress;

        Score = 0;

        HighScore = Encrypting.Encrypt(PlayerPrefs.GetInt("HighScore"));
        wallTouchScore = Encrypting.Encrypt(wallTouchScore);
        HumansAmount = PlayerPrefs.GetInt("Humans");

        scoreText = GetComponent<Text>();
        _humansText = humansTextGO.GetComponent<Text>();
        _textAnimator = humansTextGO.GetComponent<Animator>();
    }

    private void IncreaseScore(int ToAdd) {
        Score +=  Encrypting.Encrypt(ToAdd);
        IncreaseHumans();
        UpdateUI();
    }

    private void DecreaseScore() {
        if (Score - wallTouchScore > 0)
            Score -= wallTouchScore;
        UpdateUI();
    }

    private void IncreaseHumans() {
        HumansAmount++;
        if (HumansAmount % 50 == 0) 
            ShowAchieve();
    }

    private void UpdateUI() 
    {
        scoreText.text = $"{Encrypting.Decipher(Score)}";
    }

    private void ShowAchieve() {
        _humansText.text = $"You've killed {HumansAmount} humans";
        _textAnimator.SetTrigger("IsComplete");
    }

    public static int GetScore() => Encrypting.Decipher(Score);

    public static int GetHighScore() => PlayerPrefs.GetInt("HighScore");

    public static void SaveProgress() {
        SaveHighScore();
        SaveHumansAmount();
    }

    private static void SaveHighScore() {
        if (Score > HighScore)
            PlayerPrefs.SetInt("HighScore", Encrypting.Decipher(Score));
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