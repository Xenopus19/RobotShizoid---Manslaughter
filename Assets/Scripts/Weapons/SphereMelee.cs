using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMelee : Weapon
{
    [SerializeField] float AttackRadius;
    public override void Attack(Vector3 AttackPosition)
    {
        Collider[] AttackedColliders = Physics.OverlapSphere(AttackPosition, AttackRadius);

        foreach(Collider collider in AttackedColliders)
        {
            Health AttackedHealth = collider.gameObject.GetComponent<EnemyHealth>();
            if (AttackedHealth!=null)
            {
                AttackedHealth.GetDamage(Damage);
            }
        }
    }
}
