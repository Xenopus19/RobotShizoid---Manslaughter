using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    public float HealthAmount { get; private set; }

    private void Start()
    {
        RestoreHealth();
    }

    public void GetDamage(float Damage) 
    {
        HealthAmount -= Damage;
        Debug.LogError(HealthAmount);

        if(HealthAmount<=0)
        {
            Die();
        }
    }

    public void RestoreHealth()
    {
        HealthAmount = MaxHealth;
    }

    public virtual void Die() { }

}
