using System;

public static class GlobalEvents
{
    public static Action OnPlayerDiedEvent;
    public static Action<int> OnEnemyKilledEvent;
    public static Action OnEnemyTouchedWallEvent;
    public static Action OnBossKilled;

    public static void EnemyTouchedWall() 
    {
        if (OnEnemyTouchedWallEvent != null) 
        {
            OnEnemyTouchedWallEvent.Invoke();
        }
    }

    public static void EnemyKilled(int ScoreBonus)
    {
        if(OnEnemyKilledEvent != null)
        {
            OnEnemyKilledEvent.Invoke(ScoreBonus);
        }
    }

    public static void PlayerDied()
    {
        if (OnPlayerDiedEvent != null)
        {
            OnPlayerDiedEvent?.Invoke();
        }
    }

    public static void BossKilled()
    {
        if (OnBossKilled != null)
        {
            OnBossKilled?.Invoke();
        }
    }
}
