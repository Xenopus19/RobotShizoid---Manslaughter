using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public string AnimationName;
    public float Damage;
    public float Cooldown;
    public Sprite Icon;

    private bool IsAbleToAttack = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    public virtual void Attack(Vector3 AttackPosition) 
    {
        if (!IsAbleToAttack) return;

        DamageCollidedObjects(GetAttackedColliders(AttackPosition));
        PlayAnimation();

        StartCoroutine(nameof(StartCooldown));
    }

    public void DamageCollidedObjects(Collider[] AttackedColliders)
    {
        foreach (Collider collider in AttackedColliders)
        {
            Health AttackedHealth = collider.gameObject.GetComponent<EnemyHealth>();
            if (AttackedHealth != null)
            {
                Debug.LogWarning(AttackedHealth.name);
                AttackedHealth.GetDamage(Damage);
            }
        }
    }
    private void PlayAnimation()
    {
        animator.SetTrigger(AnimationName);
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
