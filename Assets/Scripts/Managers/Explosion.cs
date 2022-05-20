using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject ExplosionPrefab;
    private void OnDestroy()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }
}
