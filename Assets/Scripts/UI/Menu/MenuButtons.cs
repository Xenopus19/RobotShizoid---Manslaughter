using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {
    [SerializeField] private Button StartGameButton = null;
    [SerializeField] private Button SettingsButton = null;
    [SerializeField] private Button GoToMenuButton = null;
    [SerializeField] private Button QuitGameButton = null;
    [SerializeField] private Button DevelopersButton = null;
    //[SerializeField] GameObject Developers;

    public Animator _animator;

    private void Start() {
        Time.timeScale = 1;
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        if (StartGameButton != null)
            StartGameButton.onClick.AddListener(StartGame);

        if (SettingsButton != null)
            SettingsButton.onClick.AddListener(OpenSettings);

        if (GoToMenuButton != null)
            GoToMenuButton.onClick.AddListener(CloseSettings);

        if (QuitGameButton != null)
            QuitGameButton.onClick.AddListener(QuitGame);

        if (DevelopersButton != null)
            DevelopersButton.onClick.AddListener(OpenDevelopers);

        _animator = GetComponent<Animator>();
    }

    public void StartGame() => SceneManager.LoadScene("Arena");

    public void OpenSettings() => _animator.SetBool("IsOpening", true);

    public void CloseSettings() => _animator.SetBool("IsOpening", false);

    public void QuitGame() => Application.Quit();

    public void OpenDevelopers() {
        //Developers.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CloseDevelopers() {
        //Developers.SetActive(false);
        gameObject.SetActive(true);
    }
}