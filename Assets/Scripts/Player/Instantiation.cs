using UnityEngine;

public class Instantiation : MonoBehaviour {
    [SerializeField] private GameObject PlayerPrefab;
    private void Awake() {
        Instantiate();
    }

    public void Instantiate() {
        GameObject Shizoid = Instantiate(PlayerPrefab, transform.position, transform.rotation);
    }
}