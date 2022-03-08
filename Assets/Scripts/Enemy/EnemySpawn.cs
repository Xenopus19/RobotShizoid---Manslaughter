using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();

    [SerializeField] private float TimeBetweenSpawn = 3f;
    [SerializeField] private float TimeToWaitWave = 2.5f;
    [SerializeField] private float WaveTime = 30f;
    [SerializeField] private int WavesAmount = 0;
    [SerializeField] private float coefficientSpeed = 0.05f;
    [SerializeField] private float coefficientTime = 0.01f;
    void Start() => StartCoroutine("StartSpawn");

    private IEnumerator StartSpawn() {
        InvokeRepeating("SpawnEnemy", TimeToWaitWave, TimeBetweenSpawn);
        yield return new WaitForSeconds(WaveTime);
        ChangeValuesForNewWave();
        CancelInvoke("SpawnEnemy");
        StartCoroutine("StartSpawn");
    }

    public void SpawnEnemy() {
        int i = Random.Range(0, 4);
        GameObject Enemy = Instantiate(EnemyPrefab, SpawnPositions[i].transform.position, SpawnPositions[i].transform.rotation);
        Enemy.GetComponent<NavMeshAgent>().speed += WavesAmount * coefficientSpeed;
    }

    private void ChangeValuesForNewWave() {
        WavesAmount++;
        TimeBetweenSpawn -= WavesAmount * coefficientTime;
    }
}
