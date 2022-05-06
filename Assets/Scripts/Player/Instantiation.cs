using UnityEngine;

public class Instantiation : MonoBehaviour {
    [SerializeField] private GameObject PlayerPrefab;
    private void OnEnable() =>
        Instantiate();

    public void Instantiate() => 
        Instantiate(PlayerPrefab, transform.position, transform.rotation);
}