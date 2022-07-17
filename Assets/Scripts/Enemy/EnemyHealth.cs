using System;
using UnityEngine;

public class EnemyHealth : Health
{
    public Action OnDeath;
    [SerializeField] int ScoreBonus;
    public override void Die()
    {
        GlobalEvents.EnemyKilled(ScoreBonus);
        if (OnDeath != null) OnDeath.Invoke();
    }
}
