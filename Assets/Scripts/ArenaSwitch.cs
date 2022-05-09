using UnityEngine;
using System.Collections.Generic;

public class ArenaSwitch : MonoBehaviour
{
    [SerializeField] List<GameObject> Arenas = new List<GameObject>();
    private GameObject Arena;
    private int ArenaIndex;
    private Instantiation instantiation;

    [SerializeField] GameObject SwitchPanel;
    void Awake() =>
        StartGame();

    private void StartGame()
    {
        ArenaIndex = GetRandomArenaIndex();
        Arena = Arenas[ArenaIndex];
        Arena.SetActive(true);
        instantiation = GetComponent<Instantiation>();
        instantiation.Init(GetNewPlayerPosition());
    }

    public void SwitchArena()
    {
        SelectRandomArenaIndex();
        SwitchPanel.SetActive(true);
        Arena.SetActive(false);
        DeleteArenaObjects();
        Arena = Arenas[ArenaIndex];
        Arena.SetActive(true);
        ReplacePlayer();
    }

    private void SelectRandomArenaIndex()
    {
        int SelectedArenaIndex;
        do
        {
            SelectedArenaIndex = GetRandomArenaIndex();
        } while (ArenaIndex == SelectedArenaIndex);
        ArenaIndex = SelectedArenaIndex;
    }

    private void DeleteArenaObjects()
    {
        GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyObjects)
            Destroy(Enemy);
    }

    private void ReplacePlayer()
    {
        Vector3 NewPosition = GetNewPlayerPosition();
        GameObject.FindGameObjectWithTag("PlayerObject").transform.localPosition = NewPosition;
    }

    private Vector3 GetNewPlayerPosition() =>
        GameObject.Find($"PlayerSpawnPoint{ArenaIndex + 1}").transform.position;

    private int GetRandomArenaIndex() =>
        Random.Range(0, Arenas.Count);
}
