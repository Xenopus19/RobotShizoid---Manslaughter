using UnityEngine;

public class OnDestroyParticleCreator : MonoBehaviour
{
    [SerializeField] GameObject Particle;
    private void OnDestroy()
    {
        Instantiate(Particle, transform.position, Quaternion.identity);
    }
}
