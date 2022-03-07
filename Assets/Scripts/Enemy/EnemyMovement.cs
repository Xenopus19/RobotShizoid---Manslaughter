using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    private GameObject Target;
    private GameObject Player;

    private float MaxDistanceToPlayer = 100f;
    private float IncreasingSpeed = 1.2f;
    private NavMeshAgent Agent;
    private void Start() {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Target = GameObject.FindGameObjectWithTag("Target");
    }
    void Update() {
        Move();
    }

    private void Move() {
        float distanceToPlayer = Math.Length(Player.transform.position.x, transform.position.x, Player.transform.position.z, transform.position.z);
        if (distanceToPlayer < MaxDistanceToPlayer) {
            Agent.destination = Player.transform.position;
            Agent.speed += IncreasingSpeed;
        } else {
            Vector3 TargetPosition = new Vector3(transform.position.x, transform.position.y, Target.transform.position.z);
            Agent.destination = TargetPosition;
        }
    }

}
