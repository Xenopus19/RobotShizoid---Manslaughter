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

    [Header("Rare Enemy Chances")]
    [SerializeField] private float RangeChance;

    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();

    [SerializeField] private float TimeBetweenSpawn = 3f;
    [SerializeField] private float TimeToWaitWave = 2.5f;
    [SerializeField] private float WaveTime = 30f;
    [SerializeField] private int WavesAmount = 0;
    [SerializeField] private float coefficientSpeed = 0.05f;
    [SerializeField] private float coefficientTime = 0.01f;

    void Start()
    {
        StartCoroutine("StartSpawn");
        GlobalEventManager.OnPlayerDiedEvent += DisableSpawningIfPlayerIsDead;
    }

    private IEnumerator StartSpawn() 
    {
        InvokeRepeating("SpawnEnemy", TimeToWaitWave, TimeBetweenSpawn);
        yield return new WaitForSeconds(WaveTime);
        ChangeValuesForNewWave();
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
        if(Chance <= RangeChance)
        {
            return RangeEnemyPrefab;
        }
        return EnemyPrefab;
    }

    private void ChangeValuesForNewWave() 
    {
        WavesAmount++;
        TimeBetweenSpawn -= WavesAmount * coefficientTime;
        OnNewWaveStart.Invoke(WavesAmount);
    }

    private void DisableSpawningIfPlayerIsDead()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

    private void OnDestroy() 
    {
        GlobalEventManager.OnPlayerDiedEvent -= DisableSpawningIfPlayerIsDead;
    }
}
