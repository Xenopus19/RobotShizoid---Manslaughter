using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Die()
    {
        Debug.Log("Enemy died");
        GlobalEventManager.OnEnemyKilled();
    }
}
