using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour 
{
    [SerializeField] private string[] PossibleDeathMassages;
    [SerializeField] private GameObject DeathCamera;
    [SerializeField] private GameObject GameCanvas;

    [Header("UI Elements")]
    [SerializeField] private Text DeathMassageText;

    [SerializeField] private Text Score;
    [SerializeField] private Text BestScore;
    [SerializeField] private GameObject NewBest;

    private void Awake() 
    {
        GlobalEventManager.OnPlayerDiedEvent += SetDeathScreen;
        gameObject.SetActive(false);
    }

    private void SetDeathScreen() 
    {
        DeathCamera.SetActive(true);
        //Time.timeScale = 0;
        TurnOffGameCanvas();
        gameObject.SetActive(true);
        GenerateDeathMessage();
        SetScoreText();
        StopAllCoroutines();
    }

    private void TurnOffGameCanvas()
    {
        GameCanvas.SetActive(false);
    }

    private void GenerateDeathMessage() 
    {
        Debug.Log("sdsd");
        DeathMassageText.text = PossibleDeathMassages[Random.Range(0, PossibleDeathMassages.Length - 1)];
    }

    private void SetScoreText() 
    {
        int ScoreValue = ScoreCounter.GetScore();
        int BestScoreValue = ScoreCounter.GetHighScore();
        Score.text = "Score: " + ScoreValue;
        BestScore.text = "Best Score: " + BestScoreValue;

        if (ScoreValue > BestScoreValue)
            NewBest.SetActive(true);
    }

    private void OnDestroy() 
    {
        GlobalEventManager.OnPlayerDiedEvent -= SetDeathScreen;
    }

    public void PlayAgain() => SceneManager.LoadScene("Arena");

    public void GoToMenu() => SceneManager.LoadScene("Menu");
}