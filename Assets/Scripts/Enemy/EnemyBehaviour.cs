using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour 
{
    [SerializeField] private float WallTouchDamage;
    [SerializeField] private float PlayerTouchDamage;
    public Animator _animator;

    private GameObject Target;
    [HideInInspector] public GameObject Player;

    private float MaxDistanceToPlayer = 100f;
    private float IncreasingSpeed = 1.2f;
    [HideInInspector] public NavMeshAgent Agent;
    private PlayerHealth playerHealth;
    public float speed;

    public void Start() 
    {
        GlobalEventManager.OnPlayerDiedEvent += DisableIfPlayerIsDead;
        Agent = GetComponent<NavMeshAgent>();
        speed = Agent.speed;
        Player = GameObject.FindGameObjectWithTag("Player");
        Target = GameObject.FindGameObjectWithTag("Target");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    public void Update() 
    {
        Move();
    }

    public void Move() 
    {
        float distanceToPlayer = Math.Length(Player.transform.position.x, transform.position.x, Player.transform.position.z, transform.position.z);
        if (distanceToPlayer < MaxDistanceToPlayer) 
        {
            ReactOnPlayer();
        }
        else 
        {
            FarFromPlayer();
        }
    }

    public virtual void ReactOnPlayer()
    {
        Agent.destination = Player.transform.position;
        Agent.speed = speed + IncreasingSpeed;
    }

    public virtual void FarFromPlayer()
    {
        Vector3 TargetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        Agent.destination = TargetPosition;
    }

    public void OnCollisionEnter(Collision collision) 
    {
        GameObject CollidedObject = collision.gameObject;

        if (CollidedObject == Target) 
        {
            playerHealth.GetDamage(WallTouchDamage);
            GlobalEventManager.EnemyTouchedWall();
        } 
        else if (CollidedObject == Player) 
        {
            playerHealth.GetDamage(PlayerTouchDamage);
            _animator.SetFloat("ProbabilityAnimation", Random.value);
        }
    }

    private void DisableIfPlayerIsDead()
    {
        print("sdsad");
        gameObject?.SetActive(false);
    }

    private void OnDisable()
    {
        GlobalEventManager.OnPlayerDiedEvent -= DisableIfPlayerIsDead;
        StopAllCoroutines();
    }

    private void OnDestroy() {
        GlobalEventManager.OnPlayerDiedEvent -= DisableIfPlayerIsDead;
    }
}