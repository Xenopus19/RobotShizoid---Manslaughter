using System.Collections;
using UnityEngine;

public struct WaveData
{
    public int NumberOfWave;
    public float EnemySpeed;

    public WaveData(int waveNum, float speed)
    {
        NumberOfWave = waveNum;
        EnemySpeed = speed; 
    }
}

public class WaveController : MonoBehaviour
{
    public static System.Action<int> OnNewWaveStart;

    [Header("Wave Data")]

    [SerializeField] private float TimeToWaitWave = 2.5f;
    [SerializeField] private float WaveTime = 30f;
    [SerializeField] private float coefficientSpeed = 0.05f;

    private static int WavesAmount = 0;

    private WaveData CurrentWave;
    private EnemySpawn enemySpawn;

    private void OnEnable()
    {
        WavesAmount = 0;
        enemySpawn = GetComponent<EnemySpawn>();   
        StartCoroutine(nameof(StartSpawn));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StopAllCoroutines();
    }

    private IEnumerator StartSpawn()
    {
        ChangeValuesForNewWave();
        CurrentWave = new WaveData(WavesAmount, coefficientSpeed);
        yield return new WaitForSeconds(TimeToWaitWave);
        enemySpawn.StartSpawn(WaveTime, CurrentWave);

        yield return new WaitForSeconds(WaveTime);
        StopCoroutine(StartSpawn());
        StartCoroutine(StartSpawn());
    }

    private void ChangeValuesForNewWave()
    {
        WavesAmount++;
        if (WavesAmount != 1)
            OnNewWaveStart.Invoke(WavesAmount);
    }
}
