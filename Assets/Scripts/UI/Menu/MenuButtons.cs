using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {
    [SerializeField] private Button StartGameButton = null;
    [SerializeField] private Button SettingsButton = null;
    [SerializeField] private Button TutorialButton = null;
    [SerializeField] private Button GoToMenuSetButton = null;
    [SerializeField] private Button QuitGameButton = null;
    [SerializeField] private Button DevelopersButton = null;
    [SerializeField] private Button GoToMenuDevButton = null;

    public Animator _animator;

    private void Start() {
        Time.timeScale = 1;
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        if (StartGameButton != null)
            StartGameButton.onClick.AddListener(delegate { OpenScene("Arena"); });

        if (SettingsButton != null)
            SettingsButton.onClick.AddListener(delegate { SetBool("IsOpeningSet", true); });

        if (TutorialButton != null)
            TutorialButton.onClick.AddListener(delegate { OpenScene("Tutorial"); });

        if (GoToMenuSetButton != null)
            GoToMenuSetButton.onClick.AddListener(delegate { SetBool("IsOpeningSet", false); });

        if (QuitGameButton != null)
            QuitGameButton.onClick.AddListener(QuitGame);

        if (DevelopersButton != null)
            DevelopersButton.onClick.AddListener(delegate { SetBool("IsOpeningDev", true); });

        if (GoToMenuDevButton != null)
            GoToMenuDevButton.onClick.AddListener(delegate { SetBool("IsOpeningDev", false); });

        _animator = GetComponent<Animator>();
    }

    public void OpenScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void SetBool(string parameter, bool isParameter) => _animator.SetBool(parameter, isParameter);

    public void QuitGame() => Application.Quit();
}