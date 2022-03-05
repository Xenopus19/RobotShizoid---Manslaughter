using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private int LivesAmount = 3;
    public override void Die()
    {
        Debug.Log("ShizoidDied");
        LivesAmount--;

        if (LivesAmount < 0)
        {
            GlobalEventManager.OnPlayerDied();
        }
        else
        {
            RestoreHealth();
        }
    }
}
