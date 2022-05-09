using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour 
{
    public static Action<int> OnNewWaveStart;
    
    [Header("Enemies")]
    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();

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

    void OnEnable()
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
        float Chance = UnityEngine.Random.value;
        float j = 0.5f;
        for (int i = 0; i < Enemies.Count; i++, j /= 2)
        {
            if(Chance >= j)
                return Enemies[i];
        }
        return Enemies[0];
    }

    private void ChangeValuesForNewWave() 
    {
        WavesAmount++;
        if (WavesAmount % 5 != 0)
            OnNewWaveStart.Invoke(WavesAmount);
    }

    private void CheckArenaSwitch()
    {
        if (WavesAmount % 5 == 0)
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
