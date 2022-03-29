using UnityEngine;

public class BoxHealth : MonoBehaviour {
    public float Recovery;
    [SerializeField] GameObject Explosion;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerHealth>().RecoverHealth(Recovery);
            Destroy(gameObject);
        }
    }
    private void OnDestroy() {
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }
}
