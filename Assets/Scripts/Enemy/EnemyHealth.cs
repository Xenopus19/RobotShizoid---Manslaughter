
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] int ScoreBonus;
    public override void Die()
    {
        GlobalEventManager.EnemyKilled(ScoreBonus);
        Destroy(gameObject);
    }
}
