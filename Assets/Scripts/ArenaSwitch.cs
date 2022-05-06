using UnityEngine;
using System.Collections.Generic;

public class ArenaSwitch : MonoBehaviour
{
    [SerializeField] List<GameObject> Arenas = new List<GameObject>();
    private GameObject Arena;
    private int ArenaIndex;
    void Awake() =>
        TurnOnArena();

    private void TurnOnArena()
    {
        ArenaIndex = GetRandomArenaIndex();
        Arena = Arenas[ArenaIndex];
        Arena.SetActive(true);
    }

    public void SwitchArena()
    {
        SelectRandomArenaIndex();
        Arena.SetActive(false);
        DeleteArenaGameObjects();
        Arena = Arenas[ArenaIndex];
        Arena.SetActive(true);
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

    private void DeleteArenaGameObjects()
    {
        GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyObjects)
            Destroy(Enemy);
        Destroy(GameObject.FindGameObjectWithTag("PlayerObject"));
    }

    private int GetRandomArenaIndex() =>
        Random.Range(0, Arenas.Count);
}
