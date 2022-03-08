using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float WallTouchDamage;
    [SerializeField] float PlayerTouchDamage;

    private GameObject Target;
    private GameObject Player;

    private float MaxDistanceToPlayer = 100f;
    private float IncreasingSpeed = 1.2f;
    private NavMeshAgent Agent;
    private PlayerHealth playerHealth;
    public float speed;

    private void Start() {
        Agent = GetComponent<NavMeshAgent>();
        speed = Agent.speed;
        Player = GameObject.FindGameObjectWithTag("Player");
        Target = GameObject.FindGameObjectWithTag("Target");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }
    void Update() {
         Move();
    }

    private void Move() {
        float distanceToPlayer = Math.Length(Player.transform.position.x, transform.position.x, Player.transform.position.z, transform.position.z);
        if (distanceToPlayer < MaxDistanceToPlayer) {
            Agent.destination = Player.transform.position;
            Agent.speed = speed + IncreasingSpeed;
        } else {
            Vector3 TargetPosition = new Vector3(transform.position.x, transform.position.y, Target.transform.position.z);
            Agent.destination = TargetPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject CollidedObject = collision.gameObject;

        if(CollidedObject == Target)
        {
            playerHealth.GetDamage(WallTouchDamage);
            Destroy(gameObject);
        }
        else if(CollidedObject == Player)
        {
            playerHealth.GetDamage(PlayerTouchDamage);
        }
    }
}
