using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMeleeWeapon : Weapon
{
    [SerializeField] float AttackLength;
    [SerializeField] float AttackWidth;
    public override Collider[] GetAttackedColliders(Vector3 AttackPosition)
    {
        Vector3 AttackBorder = AttackPosition;
        AttackBorder.z += AttackLength;
        return Physics.OverlapCapsule(AttackPosition, AttackBorder, AttackWidth);
    }
}
