using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour
{
    public Action OnAttack;
    public float Damage;
    public float Cooldown;
    public Sprite Icon;

    private bool IsAbleToAttack = true;


    public virtual void Attack(Vector3 AttackPosition) 
    {
        if (!IsAbleToAttack) return;

        DamageCollidedObjects(GetAttackedColliders(AttackPosition));

        if (OnAttack != null) OnAttack.Invoke();

        StartCoroutine(nameof(StartCooldown));
    }

    public void DamageCollidedObjects(Collider[] AttackedColliders)
    {
        foreach (Collider collider in AttackedColliders)
        {
            Health AttackedHealth = collider.gameObject.GetComponent<EnemyHealth>();
            if (AttackedHealth != null)
            {
                AttackedHealth.GetDamage(Damage);
            }
        }
    }

    public virtual Collider[] GetAttackedColliders(Vector3 AttackPosition)
    {
        return null;
    }

    public IEnumerator StartCooldown()
    {
        IsAbleToAttack = false;
        yield return new WaitForSeconds(Cooldown);
        IsAbleToAttack = true;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
