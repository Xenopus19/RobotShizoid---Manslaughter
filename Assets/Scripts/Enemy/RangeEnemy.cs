using UnityEngine;

public class RangeEnemy : EnemyBehaviour
{
    [SerializeField] private GameObject BulletPrefab;

    [SerializeField] private float TimeBetweenShots;
    [SerializeField] private Transform ShotOrigin;
    [SerializeField] private bool IsMovable = true;
    private bool IsNearPlayer;

    private new void Update()
    {
        if (!IsMovable) speed = 0;
        Move();
        if (IsNearPlayer) transform.LookAt(Player.transform);
    }


    public override void ReactOnPlayer()
    {
        Agent.speed = 0;
        //Agent.SetDestination(Player.transform.position);
        if(!IsNearPlayer)
        {
            InvokeRepeating(nameof(MakeShot), 0f, TimeBetweenShots);
            IsNearPlayer = true;
        }
        
    }

    public override void FarFromPlayer()
    {
        if (IsInvoking()) CancelInvoke();
        Agent.speed = speed;
        base.FarFromPlayer();
        IsNearPlayer = false;
    }

    private void MakeShot()
    {
        _animator.SetTrigger("Shot");
        Instantiate(BulletPrefab, ShotOrigin.position, transform.rotation);
    }
}
