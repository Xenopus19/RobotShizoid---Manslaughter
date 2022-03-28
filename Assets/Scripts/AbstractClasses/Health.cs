using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    public float MaxHealth;
    public float HealthAmount { get; protected set; }
    public Action OnHealthChanged;

    
    private void Start()
    {
        RestoreHealth();
    }

    public virtual void GetDamage(float Damage) 
    {
        HealthAmount -= Damage;

        OnHealthChanged?.Invoke();

        if (HealthAmount <= 0)
        {
            Die();
        }
    }

    public void RestoreHealth()
    {
        HealthAmount = MaxHealth;
        OnHealthChanged?.Invoke();
    }

    public virtual void Die() { }

}
