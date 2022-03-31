using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float Speed;
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.GetDamage(Damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.isStatic)
        {
            Destroy(gameObject);
        }
    }
}
