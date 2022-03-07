using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEventManager
{
    public static Action OnPlayerDiedEvent;
    public static Action OnEnemyKilledEvent;

    public static void EnemyKilled()
    {
        if(OnEnemyKilledEvent!=null)
        {
            OnEnemyKilledEvent.Invoke();
        }
    }

    public static void PlayerDied()
    {
        if (OnPlayerDiedEvent != null)
        {
            OnPlayerDiedEvent.Invoke();
        }
    }
}
