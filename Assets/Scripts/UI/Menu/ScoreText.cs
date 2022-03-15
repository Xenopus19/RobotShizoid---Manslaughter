using UnityEngine.UI;
using UnityEngine;

public class ScoreText : MonoBehaviour {
    private void Start() => ShowScore(GetScore());

    private int GetScore() {
        int score = 0;
        if (PlayerPrefs.HasKey("HighScore")) {
            score = PlayerPrefs.GetInt("HighScore");
        }
        return score;
    }

    private void ShowScore(int score) =>
        GetComponent<Text>().text = $"Best Score: {score}";
}