using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    [SerializeField] Button StartGameButton = null;
    [SerializeField] Button SettingsButton = null;
    [SerializeField] Button GoToMenuButton = null;
    [SerializeField] Button QuitGameButton = null;
    [SerializeField] Button DevelopersButton = null;
    public Animator _animator;
    //[SerializeField] GameObject Developers;

    void Start() {
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
