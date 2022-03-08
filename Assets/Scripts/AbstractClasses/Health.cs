using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    public float MaxHealth;
    public float HealthAmount { get; private set; }
    public Action OnHealthChanged;

    
    private void Start()
    {
        RestoreHealth();
    }

    public virtual void GetDamage(float Damage) 
    {
        CoreGetDamage(Damage);
    }
    public void CoreGetDamage(float Damage)
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
