using UnityEngine;

public class SphereMelee : Weapon
{
    [SerializeField] public float AttackRadius;
    [SerializeField] public float ForwardShift;
    
    

    public override Collider[] GetAttackedColliders(Vector3 AttackPosition)
    {
        AttackPosition.z += ForwardShift;
        Collider[] AttackedColliders = Physics.OverlapSphere(AttackPosition, AttackRadius);
        return AttackedColliders;
    }
}
