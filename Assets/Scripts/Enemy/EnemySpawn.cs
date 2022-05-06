using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour 
{
    public static Action<int> OnNewWaveStart;
    
    [Header("Enemies")]
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject RangeEnemyPrefab;
    [SerializeField] private GameObject FatEnemy;

    [Header("Rare Enemy Chances")]
    [SerializeField] private float RangeChance;
    [SerializeField] private float FatEnemyChance;

    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();

    [Header("Wave Data")]
    [SerializeField] private float TimeBetweenSpawn = 3f;
    [SerializeField] private float TimeToWaitWave = 2.5f;
    [SerializeField] private float WaveTime = 30f;
    [SerializeField] private float coefficientSpeed = 0.05f;
    [SerializeField] private ArenaSwitch arenaSwitch;
    private static int WavesAmount = 0;

    void Start()
    {
        WavesAmount = 0;
        StartCoroutine("StartSpawn");
        GlobalEventManager.OnPlayerDiedEvent += DisableSpawningIfPlayerIsDead;
    }

    private IEnumerator StartSpawn() 
    {
        InvokeRepeating("SpawnEnemy", TimeToWaitWave, TimeBetweenSpawn);
        yield return new WaitForSeconds(WaveTime);
        ChangeValuesForNewWave();
        CheckArenaSwitch();
        CancelInvoke("SpawnEnemy");
        StartCoroutine("StartSpawn");
    }

    public void SpawnEnemy() 
    {
        int i = UnityEngine.Random.Range(0, 4);
        GameObject PrefabToSpawn = ChooseEnemyToSpawn();
        GameObject Enemy = Instantiate(PrefabToSpawn, SpawnPositions[i].transform.position, SpawnPositions[i].transform.rotation);
        Enemy.GetComponent<NavMeshAgent>().speed += WavesAmount * coefficientSpeed;
    }

    private GameObject ChooseEnemyToSpawn()
    {
        float Chance = UnityEngine.Random.Range(0, 100);
        if (Chance <= RangeChance && Chance > FatEnemyChance)
        {
            return RangeEnemyPrefab;
        }
        else if (Chance <= FatEnemyChance)
        {
            return FatEnemy;
        }
        return EnemyPrefab;
    }

    private void ChangeValuesForNewWave() 
    {
        WavesAmount++;
        OnNewWaveStart.Invoke(WavesAmount);
    }

    private void CheckArenaSwitch()
    {

        arenaSwitch.SwitchArena();
    }

    private void DisableSpawningIfPlayerIsDead() =>
        gameObject.SetActive(false);

    private void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

    private void OnDestroy() =>
        GlobalEventManager.OnPlayerDiedEvent -= DisableSpawningIfPlayerIsDead;
}
