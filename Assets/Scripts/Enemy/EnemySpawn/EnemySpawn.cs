using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour 
{
    [SerializeField] private float TimeBetweenSpawn = 3f;

    [Header("Enemies")]
    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();

    [Header("Arena Borders")]
    [SerializeField] private Transform MinPos;
    [SerializeField] private Transform MaxPos;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();

    private WaveData CurrentWave;

    void OnEnable()
    {
        GlobalEvents.OnPlayerDiedEvent += DisableSpawningIfPlayerIsDead;
    }

    public void StartSpawn(float WaveTime, WaveData wave)
    {
        CurrentWave = wave;
        InvokeRepeating(nameof(SpawnEnemy), TimeBetweenSpawn, TimeBetweenSpawn);
        print(IsInvoking());
        EndSpawnOverSeconds(WaveTime);
    }

    public IEnumerable EndSpawnOverSeconds(float SpawnTime)
    {
        yield return new WaitForSeconds(SpawnTime);
        CancelInvoke();
    }

    public void SpawnEnemy() 
    {
        int i = Random.Range(0, 4);
        GameObject PrefabToSpawn = ChooseEnemyToSpawn();
        GameObject Enemy = Instantiate(PrefabToSpawn, SpawnPositions[i].transform.position, SpawnPositions[i].transform.rotation);
        ConfigEnemy(Enemy);
    }

    private GameObject ChooseEnemyToSpawn()
    {
        float Chance = Random.value;
        float ChanceEnemy = Enemies.Count * 0.1f;

        for (int i = 0; i < Enemies.Count; i++, ChanceEnemy += 0.1f)
        {
            if (Chance <= ChanceEnemy)
                return Enemies[i];
        }

        return Enemies[Enemies.Count - 1];
    }

    private void ConfigEnemy(GameObject Enemy)
    {
        Enemy.GetComponent<NavMeshAgent>().speed += CurrentWave.NumberOfWave * CurrentWave.EnemySpeed;

        RandomSpawn(Enemy);
    }

    public void RandomSpawn(GameObject Enemy)
    {
        RandomSpawnOnArena randomSpawnOnArena = Enemy.GetComponent<RandomSpawnOnArena>();
        if (randomSpawnOnArena != null && MinPos != null && MaxPos != null)
        {
            randomSpawnOnArena.MaxPosition = MaxPos.position;
            randomSpawnOnArena.MinPosition = MinPos.position;
        }
    }

    private void DisableSpawningIfPlayerIsDead() =>
        gameObject.SetActive(false);

    public void StopSpawn()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

    private void OnDisable()
    {
        StopSpawn();
    }

    private void OnDestroy()
    {
        GlobalEvents.OnPlayerDiedEvent -= DisableSpawningIfPlayerIsDead;
    }
}
