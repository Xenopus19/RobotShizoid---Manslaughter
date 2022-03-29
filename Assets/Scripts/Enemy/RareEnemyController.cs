using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareEnemyController : MonoBehaviour
{
    [SerializeField] float RareEnemyChance;
    [SerializeField] GameObject RareEnemyPrefab;

    private void Awake()
    {
        float Chance = Random.Range(0, 100);
        if(Chance<= RareEnemyChance)
        {
            Instantiate(RareEnemyPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
