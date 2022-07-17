using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private int SpawnOnWave;

    [Header("Boss Info")]
    [SerializeField] private GameObject Boss;
    [SerializeField] private Transform BossSpawnPos;

    private EnemySpawn enemySpawn;
    private WaveController waveController;

    private void OnEnable()
    {
        WaveController.OnNewWaveStart += CheckBossSpawn;
        enemySpawn = GetComponent<EnemySpawn>();
        waveController = GetComponent<WaveController>();
    }

    private void CheckBossSpawn(int CurrentWaveNumber)
    {
        if (CurrentWaveNumber % SpawnOnWave == 0)
            SpawnBoss();
    }

    private void SpawnBoss()
    {
        DestroyEnemies();
        waveController.StopAllCoroutines();
        enemySpawn.StopSpawn();

        Instantiate(Boss, BossSpawnPos.position, Quaternion.identity);
    }

    private void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
            enemy.GetComponent<EnemyHealth>().Die();
    }

    private void OnDestroy()
    {
        WaveController.OnNewWaveStart -= CheckBossSpawn;
    }
}
