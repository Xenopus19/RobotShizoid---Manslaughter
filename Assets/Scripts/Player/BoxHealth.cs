using UnityEngine;

public class BoxHealth : MonoBehaviour {
    public float Recovery;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerHealth>().RecoverHealth(Recovery);
            Destroy(gameObject);
        }
    }
}
