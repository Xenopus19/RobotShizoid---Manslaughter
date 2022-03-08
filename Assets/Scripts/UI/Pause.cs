using UnityEngine;
using UnityEngine.AI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject EnemySpawnObject;

    private KeyCode PauseKey = KeyCode.Escape;
    private EnemySpawn enemySpawn;
    private void Start() {
        enemySpawn = EnemySpawnObject.GetComponent<EnemySpawn>();
    }

    void Update() => CheckPause();

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

    private void DoPause() {
        Time.timeScale = 0;
        PauseCanvas.SetActive(true);
    }

    private void UndoPause() {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }

    public void Continue() => UndoPause();
}
