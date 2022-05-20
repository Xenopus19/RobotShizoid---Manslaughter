using UnityEngine;

public class Instantiation : MonoBehaviour {
    [SerializeField] private GameObject PlayerPrefab;
    public void Init(Vector3 Position) =>
        Instantiate(Position);

    private void Instantiate(Vector3 Position) => 
        Instantiate(PlayerPrefab, Position, transform.rotation);
}