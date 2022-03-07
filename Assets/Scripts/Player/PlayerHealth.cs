using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public Action OnLivesChange;
    public int LivesAmount;
    public override void Die()
    {
        LivesAmount--;
        OnLivesChange?.Invoke();

        if (LivesAmount < 0)
        {
            GlobalEventManager.PlayerDied();
        }
        else
        {
            RestoreHealth();
        }
    }
}
