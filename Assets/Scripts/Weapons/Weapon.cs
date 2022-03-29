using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour
{
    public float AttackDelay;
    public Action OnAttack;
    public float Damage;
    public float Cooldown;
    public Sprite Icon;
    public int Price;
    public WeaponEffects weaponEffects;

    private bool IsAbleToAttack = true;


    public virtual void Attack(Vector3 AttackPosition) 
    {
        if (!IsAbleToAttack) return;

        if (OnAttack != null) OnAttack.Invoke();

        StartCoroutine(nameof(DoAttack), AttackPosition);

        StartCoroutine(nameof(StartCooldown));
    }

    private IEnumerator DoAttack(Vector3 AttackPosition)
    {
        yield return new WaitForSeconds(AttackDelay);

        DamageCollidedObjects(GetAttackedColliders(AttackPosition));
        if(weaponEffects != null) weaponEffects.PlaySlash();
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
