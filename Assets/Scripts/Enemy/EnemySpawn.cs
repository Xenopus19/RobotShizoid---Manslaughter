using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();

    private float TimeBetweenSpawn = 3f;
    private float TimeToWaitWave = 2.5f;
    private float TimeBetweenWaves = 30f;
    private int WavesAmount = 0;
    void Start() => StartCoroutine("StartSpawn");
    public void StopSpawnCoroutine() {
        StopCoroutine("StartSpawn");
        CancelInvoke("SpawnEnemy");
    }

    private IEnumerator StartSpawn() {
        InvokeRepeating("SpawnEnemy", TimeToWaitWave, TimeBetweenSpawn);
        yield return new WaitForSeconds(TimeBetweenWaves);
        ChangeValuesForNewWave();
        CancelInvoke("SpawnEnemy");
        StartCoroutine("StartSpawn");
    }

    public void SpawnEnemy() {
        int i = Random.Range(0, 4);
        GameObject Enemy = Instantiate(EnemyPrefab, SpawnPositions[i].transform.position, SpawnPositions[i].transform.rotation);
        Enemy.GetComponent<NavMeshAgent>().speed += WavesAmount * 0.05f;
    }

    private void ChangeValuesForNewWave() {
        WavesAmount++;
        TimeBetweenSpawn -= WavesAmount * 0.01f;
    }
}
