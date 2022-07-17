using UnityEngine;
using System.Collections.Generic;

public class ArenaSwitch : MonoBehaviour
{
    [SerializeField] List<GameObject> Arenas = new List<GameObject>();

    [SerializeField] GameObject SwitchArenaUIEffect;

    private GameObject CurrentArena;
    private int CurrentArenaIndex;
    private Instantiation PlayerCreator;
    
    void Awake() =>
        StartGame();

    private void StartGame()
    {
        CurrentArenaIndex = GetRandomArenaIndex();
        CurrentArena = Arenas[CurrentArenaIndex];
        CurrentArena.SetActive(true);
        PlayerCreator = GetComponent<Instantiation>();
        PlayerCreator.Init(GetNewPlayerPosition());

        GlobalEvents.OnBossKilled += SwitchArena;
    }


    public void SwitchArena()
    {
        TurnOffCurrentArena();

        ChooseRandomArena();
        CurrentArena.SetActive(true);
        ReplacePlayer();

        SwitchArenaUIEffect.SetActive(true);
    }

    private void TurnOffCurrentArena()
    {
        CurrentArena.SetActive(false);
        DeleteArenaObjects();
    }
    private void DeleteArenaObjects()
    {
        GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in EnemyObjects)
            Destroy(Enemy);
    }

    private void ChooseRandomArena()
    {
        SelectRandomArenaIndex();
        CurrentArena = Arenas[CurrentArenaIndex];
    }

    private void SelectRandomArenaIndex()
    {
        int SelectedArenaIndex;
        do
        {
            SelectedArenaIndex = GetRandomArenaIndex();
        } while (CurrentArenaIndex == SelectedArenaIndex);
        CurrentArenaIndex = SelectedArenaIndex;
    }

    

    private void ReplacePlayer()
    {
        Vector3 NewPosition = GetNewPlayerPosition();
        GameObject.FindGameObjectWithTag("PlayerObject").transform.localPosition = NewPosition;
    }

    private Vector3 GetNewPlayerPosition() =>
        GameObject.Find($"PlayerSpawnPoint{CurrentArenaIndex + 1}").transform.position;

    private int GetRandomArenaIndex() =>
        Random.Range(0, Arenas.Count);

    private void OnDestroy()
    {
        GlobalEvents.OnBossKilled -= SwitchArena;
    }
}
