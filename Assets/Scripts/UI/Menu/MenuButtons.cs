using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {
    [SerializeField] private Button StartGameButton = null;
    [SerializeField] private Button SettingsButton = null;
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
            StartGameButton.onClick.AddListener(StartGame);

        if (SettingsButton != null)
            SettingsButton.onClick.AddListener(OpenSettings);

        if (GoToMenuSetButton != null)
            GoToMenuSetButton.onClick.AddListener(CloseSettings);

        if (QuitGameButton != null)
            QuitGameButton.onClick.AddListener(QuitGame);

        if (DevelopersButton != null)
            DevelopersButton.onClick.AddListener(OpenDevelopers);

        if (GoToMenuDevButton != null)
            GoToMenuDevButton.onClick.AddListener(CloseDevelopers);

        _animator = GetComponent<Animator>();
    }

    public void StartGame() => SceneManager.LoadScene("Arena");

    public void OpenSettings() => _animator.SetBool("IsOpeningSet", true);

    public void CloseSettings() => _animator.SetBool("IsOpeningSet", false);

    public void OpenDevelopers() => _animator.SetBool("IsOpeningDev", true);

    public void CloseDevelopers() => _animator.SetBool("IsOpeningDev", false);

    public void QuitGame() => Application.Quit();
}