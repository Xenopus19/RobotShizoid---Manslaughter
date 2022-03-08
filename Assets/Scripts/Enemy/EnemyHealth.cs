using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] int ScoreBonus;
    public override void Die()
    {
        GlobalEventManager.EnemyKilled(ScoreBonus);
        Destroy(gameObject);
    }

    public override void GetDamage(float Damage)
    {
        CoreGetDamage(Damage);
    }
}
