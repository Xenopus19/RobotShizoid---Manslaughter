using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Target;

    private float MaxDistanceToPlayer = 30f;
    private NavMeshAgent Agent;
    private void Start() {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        Move();
    }

    private void Move() {
        float distanceToPlayer = Math.Length(Player.transform.position.x, transform.position.x, Player.transform.position.z, transform.position.z);
        if (distanceToPlayer < MaxDistanceToPlayer) {
            Agent.destination = Player.transform.position;
        } else {
            Agent.destination = Target.transform.position;
        }
    }

}
