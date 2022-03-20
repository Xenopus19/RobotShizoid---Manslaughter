using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private Transform FloorBloodOrigin;

    [SerializeField] private GameObject RagdollPrefab;
    [SerializeField] private GameObject MeatChunkParticle;
    [SerializeField] private GameObject[] FloorBloodVariants;
    private void Start()
    {
        EnemyHealth health = GetComponent<EnemyHealth>();
        health.OnDeath += CreateDeathEffects;
        health.OnHealthChanged += CreateBloodSplashes;
    }

    private void CreateBloodSplashes()
    {
        Instantiate(MeatChunkParticle, transform);
    }

    private void CreateDeathEffects()
    {
        Instantiate(FloorBloodVariants[Random.Range(0, FloorBloodVariants.Length - 1)], FloorBloodOrigin.position, Quaternion.identity);
        GameObject Corpse = Instantiate(RagdollPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }   
}
