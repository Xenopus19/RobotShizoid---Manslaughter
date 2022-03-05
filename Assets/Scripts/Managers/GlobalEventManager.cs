using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static Action OnPlayerDied;
    public static Action OnEnemyKilled;

    public static void EnemyKilled()
    {
        if(OnEnemyKilled!=null)
        {
            OnEnemyKilled.Invoke();
        }
    }

    public static void PlayerDied()
    {
        if (OnPlayerDied != null)
        {
            OnPlayerDied.Invoke();
        }
    }
}
