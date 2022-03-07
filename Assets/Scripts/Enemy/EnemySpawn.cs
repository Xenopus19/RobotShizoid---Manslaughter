using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();

    private float TimeBetweenSpawn = 3f;
    void Start() {
        InvokeRepeating("SpawnEnemy", 2f, TimeBetweenSpawn);
    }
    public void SpawnEnemy() {
        int i = Random.Range(0, 4);
        GameObject Enemy = Instantiate(EnemyPrefab, SpawnPositions[i].transform.position, SpawnPositions[i].transform.rotation);
    }
}
