using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : EnemyBehaviour
{
    [SerializeField] Rigidbody Rigidbody;

    [SerializeField] float DashCooldown;
    [SerializeField] float DashSpeed;

    private float TimeFromLastDash = 0;


    private new void Update()
    {
        Move();
        TimeFromLastDash += Time.deltaTime;
    }

    public override void ReactOnPlayer()
    {
        transform.LookAt(Player.transform.position);
        speed = 0;

        if (TimeFromLastDash < DashCooldown) return;
        Debug.Log("DASH-U");
        PerformDash();
    }

    private void PerformDash()
    {
        _animator.SetTrigger("Dash");
        TimeFromLastDash = 0;
        Vector3 Force = transform.forward * DashSpeed;
        Rigidbody.AddForce(Force, ForceMode.Impulse);
    }
}
