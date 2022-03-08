using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEventManager
{
    public static Action OnPlayerDiedEvent;
    public static Action<int> OnEnemyKilledEvent;

    public static void EnemyKilled(int ScoreBonus)
    {
        if(OnEnemyKilledEvent!=null)
        {
            OnEnemyKilledEvent.Invoke(ScoreBonus);
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
