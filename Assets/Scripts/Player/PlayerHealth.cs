using System;
using UnityEngine;

public class PlayerHealth : Health
{
    public Action OnLivesChange;
    public int LivesAmount;
    public float InvisibilityTime;

    private float InvisibilityTimePassed = 0;
    private bool IsInvisible;
    private int LivesMax = 3;
    
    private void Update()
    {
        CheckInvisibility();
    }

    public override void GetDamage(float Damage)
    {
#if(UNITY_EDITOR)
        return;
#endif
        if (IsInvisible) return;
        base.GetDamage(Damage);
        IsInvisible = true;
    }

    public void RecoverHealth(float Recovery) {
        if (HealthAmount == MaxHealth) {
            if (LivesAmount == LivesMax) 
                return;

            LivesAmount++;
            OnLivesChange?.Invoke();
            HealthAmount = Recovery;
        } else {
            HealthAmount += Recovery;
        }
        OnHealthChanged?.Invoke();
    }

    public override void Die()
    {
        LivesAmount--;
        OnLivesChange?.Invoke();

        if (LivesAmount < 0)
        {
            GlobalEvents.PlayerDied();
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
