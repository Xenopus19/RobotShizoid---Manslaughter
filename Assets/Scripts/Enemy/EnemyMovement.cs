using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private List<GameObject> Targets = new List<GameObject>();
    private NavMeshAgent Agent;
    private void Start() {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        Move();
    }

    private void Move() {
        float distanceToPlayer = Math.Length(Player.transform.position.x, transform.position.x, Player.transform.position.z, transform.position.z);
        if (distanceToPlayer < 11) {
            Agent.destination = Player.transform.position;
        } else {
            Agent.destination = Targets[Random.Range(0, 3)].transform.position;
        }
    }

}
