using UnityEngine;

public class SphereMelee : Weapon
{
    [SerializeField] public float AttackRadius;
    

    public override Collider[] GetAttackedColliders(Vector3 AttackPosition)
    {
        Collider[] AttackedColliders = Physics.OverlapSphere(AttackPosition, AttackRadius);
        return AttackedColliders;
    }
}
