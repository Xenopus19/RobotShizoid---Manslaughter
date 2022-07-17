using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private int SpawnOnWave;

    [Header("Boss Info")]
    [SerializeField] private GameObject Boss;
    [SerializeField] private Transform BossSpawnPos;

    private void OnEnable()
    {
        WaveController.OnNewWaveStart += CheckBossSpawn;
    }

    private void CheckBossSpawn(int CurrentWaveNumber)
    {
        if (CurrentWaveNumber % SpawnOnWave == 0)
            SpawnBoss();
    }

    private void SpawnBoss()
    {
        Instantiate(Boss, BossSpawnPos.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        WaveController.OnNewWaveStart -= CheckBossSpawn;
    }
}
