using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private Transform FloorBloodOrigin;

    [SerializeField] private GameObject RagdollPrefab;
    [SerializeField] private GameObject BoxPrefab;
    [SerializeField] private GameObject MeatChunkParticle;
    [SerializeField] private GameObject[] FloorBloodVariants;
    [SerializeField] private float BoxRateChance;
    private EnemyHealth health;
    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.OnDeath += CreateDeathEffects;
        health.OnDeath += CreateHealthBox;
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

    private void CreateHealthBox() 
    {
        float coefficientHealth = health.MaxHealth / 5 * BoxRateChance;
        float probability = Random.value;
        if (probability <= coefficientHealth) {
            GameObject Box = Instantiate(BoxPrefab, transform.position, Quaternion.identity);
            Box.GetComponent<BoxHealth>().Recovery = coefficientHealth * 10;
        }
    }
}
