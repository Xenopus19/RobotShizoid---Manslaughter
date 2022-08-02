using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image ProgressBar;
    [SerializeField] private Text ProgressText;

    private AsyncOperation LoadingSceneOperation;

    public void LoadScene(string name)
    {
        LoadingSceneOperation = SceneManager.LoadSceneAsync(name);
    }

    void Update()
    {
        ProgressText.text = $"{Mathf.RoundToInt(LoadingSceneOperation.progress * 100)}%";
        ProgressBar.fillAmount = LoadingSceneOperation.progress;
    }
}
