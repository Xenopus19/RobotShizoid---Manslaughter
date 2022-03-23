using System;
using UnityEngine;

public class EnemyHealth : Health
{
    public Action OnDeath;
    [SerializeField] int ScoreBonus;
    public override void Die()
    {
        GlobalEventManager.EnemyKilled(ScoreBonus);
        if (OnDeath != null) OnDeath.Invoke();
    }
}
