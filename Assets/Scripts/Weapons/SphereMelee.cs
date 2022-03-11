using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMelee : Weapon
{
    [SerializeField] float AttackRadius;
    

    public override Collider[] GetAttackedColliders(Vector3 AttackPosition)
    {
        Collider[] AttackedColliders = Physics.OverlapSphere(AttackPosition, AttackRadius);
        return AttackedColliders;
    }




}
