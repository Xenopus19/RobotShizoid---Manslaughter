using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public Action OnLivesChange;
    public int LivesAmount;
    public float InvisibilityTime;

    private float InvisibilityTimePassed = 0;
    private bool IsInvisible;
    
    private void Update()
    {
        CheckInvisibility();
    }

    public override void GetDamage(float Damage)
    {
        if (IsInvisible) return;
        base.GetDamage(Damage);
        IsInvisible = true;
    }

    public override void Die()
    {
        LivesAmount--;
        OnLivesChange?.Invoke();

        if (LivesAmount < 0)
        {
            GlobalEventManager.PlayerDied();
            gameObject.SetActive(false);
        }
        else
        {
            RestoreHealth();
        }
    }

    private void CheckInvisibility()
    {
        if(IsInvisible)
        {
            InvisibilityTimePassed += Time.deltaTime;

            if(InvisibilityTimePassed >= InvisibilityTime)
            {
                InvisibilityTimePassed = 0;
                IsInvisible = false;
            }
        }
    }

}
