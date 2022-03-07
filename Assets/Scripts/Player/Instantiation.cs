using UnityEngine;

public class Instantiation : MonoBehaviour {
    [SerializeField] private GameObject PlayerPrefab;
    void Awake() {
        GameObject Shizoid = Instantiate(PlayerPrefab, transform.position, transform.rotation);
    }
}
