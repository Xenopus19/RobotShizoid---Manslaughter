using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private GameObject RagdollPrefab;
    private void Start()
    {
        GetComponent<EnemyHealth>().OnDeath += CreateDeathEffects;
    }

    private void CreateDeathEffects()
    {
        GameObject Corpse = Instantiate(RagdollPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }   
}
