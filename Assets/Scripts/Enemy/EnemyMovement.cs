using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private NavMeshAgent Agent;
    private void Start() {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        Agent.destination = Player.transform.position;
    }
}
