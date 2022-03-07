using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMelee : Weapon
{
    [SerializeField] float AttackRadius;
    [SerializeField] float Cooldown;

    private bool IsAbleToAttack;
    public override void Attack(Vector3 AttackPosition)
    {
        if (!IsAbleToAttack) return;

        Collider[] AttackedColliders = Physics.OverlapSphere(AttackPosition, AttackRadius);

        foreach(Collider collider in AttackedColliders)
        {
            Health AttackedHealth = collider.gameObject.GetComponent<EnemyHealth>();
            if (AttackedHealth!=null)
            {
                AttackedHealth.GetDamage(Damage);
            }
        }

        StartCoroutine("StartCooldown");
    }

    private IEnumerator StartCooldown()
    {
        IsAbleToAttack = false;
        yield return new WaitForSeconds(Cooldown);
        IsAbleToAttack = true;
    }
}
