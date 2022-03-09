using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    [SerializeField] Button StartGameButton = null;
    [SerializeField] Button SettingsButton = null;
    [SerializeField] Button QuitGameButton = null;
    [SerializeField] Button DevelopersButton = null;
    //[SerializeField] GameObject Developers;

    void Start() {
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        if (StartGameButton != null) {
            StartGameButton.onClick.AddListener(StartGame);
        }
        if (SettingsButton != null) {
            SettingsButton.onClick.AddListener(OpenSettings);
        }
        if (QuitGameButton != null) {
            QuitGameButton.onClick.AddListener(QuitGame);
        }
        if (DevelopersButton != null) {
            DevelopersButton.onClick.AddListener(OpenDevelopers);
        }
    }

    public void StartGame() => SceneManager.LoadScene("Arena");
    private void OpenSettings() {

    }

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
