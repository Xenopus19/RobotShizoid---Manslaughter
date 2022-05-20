using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour
{
    public float AttackDelay;
    public Action OnAttack;
    public Action OnAttackEnemies;
    public float Damage;
    public float Cooldown;
    public Sprite Icon;
    public int Price;
    public float Drive;
    public WeaponEffects weaponEffects;

    private bool IsAbleToAttack = true;
    public BloodDrive bloodDrive;
    private BloodDriveEffects driveEffects;

    private void Awake()
    {
        if (weaponEffects == null) weaponEffects = GetComponent<WeaponEffects>();
        driveEffects = GetComponent<BloodDriveEffects>();
    }

    public virtual void Attack(Vector3 AttackPosition, BloodDrive _bloodDrive) 
    {
        if (!IsAbleToAttack) return;

        bloodDrive = _bloodDrive;

        if (OnAttack != null) OnAttack.Invoke();

        StartCoroutine(nameof(DoAttack), AttackPosition);

        StartCoroutine(nameof(StartCooldown));
    }

    private IEnumerator DoAttack(Vector3 AttackPosition)
    {
        yield return new WaitForSeconds(AttackDelay);

        DamageCollidedObjects(GetAttackedColliders(AttackPosition));
        if(weaponEffects != null) weaponEffects.CreateDelayedEffects(AttackPosition);
    }

    public void DamageCollidedObjects(Collider[] AttackedColliders)
    {
        foreach (Collider collider in AttackedColliders)
        {
            Health AttackedHealth = collider.gameObject.GetComponent<EnemyHealth>();
            EnemyEffects enemyEffects = collider.gameObject.GetComponent<EnemyEffects>();
            if (AttackedHealth != null)
            {
                float randomDamage = UnityEngine.Random.Range(Damage - 1, Damage + 2);
                if (bloodDrive != null && bloodDrive.IsBloodDrive) {
                    AttackedHealth.GetDamage(Damage * 1.25f);
                } else {
                    AttackedHealth.GetDamage(Damage);
                }

                enemyEffects.InstantiateDamage(randomDamage);
                if (bloodDrive != null) bloodDrive.IncreaseDriveValue(Drive);
                
                if (OnAttackEnemies != null) OnAttackEnemies.Invoke();
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
