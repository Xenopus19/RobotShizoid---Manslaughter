using System;

public static class GlobalEventManager
{
    public static Action OnPlayerDiedEvent;
    public static Action<int> OnEnemyKilledEvent;
    public static Action OnEnemyTouchedWallEvent;

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
}
