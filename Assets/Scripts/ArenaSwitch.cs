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

    private int GetRandomArenaIndex() =>
        Random.Range(0, Arenas.Count);
}
