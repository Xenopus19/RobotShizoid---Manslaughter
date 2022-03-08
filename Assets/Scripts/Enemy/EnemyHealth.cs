using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] int ScoreBonus;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Target") {
            Destroy();
        }
    }
    public override void Die()
    {
        GlobalEventManager.EnemyKilled(ScoreBonus);
        Destroy(gameObject);
    }

    public override void GetDamage(float Damage)
    {
        CoreGetDamage(Damage);
    }

    private void Destroy()
    {
        GlobalEventManager.EnemyDestroyed();
    }
}
