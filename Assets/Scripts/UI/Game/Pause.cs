using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject EnemySpawnObject;
    [SerializeField] Button ContinueButton;
    [SerializeField] Button MenuButton;

    private KeyCode PauseKey = KeyCode.Escape;
    void Update() => CheckPause();
    private void Start() {
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        if (ContinueButton != null) {
            ContinueButton.onClick.AddListener(Continue);
        }
        if (MenuButton != null) {
            MenuButton.onClick.AddListener(GoToMenu);
        }
    }
    private void CheckPause() {
        if (Input.GetKeyDown(PauseKey)) 
            DoUndoPause();
    }

    private void DoUndoPause() {
        if (!PauseCanvas.activeInHierarchy) {
            DoPause();
        } else {
            UndoPause();
        }
    }

    public void DoPause() {
        Time.timeScale = 0;
        PauseCanvas.SetActive(true);
    }

    private void UndoPause() {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }

    public void Continue() => UndoPause();
    public void GoToMenu() {
        //Add high score and save money
        SceneManager.LoadScene("Menu");
    }
}
