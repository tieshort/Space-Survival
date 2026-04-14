using UnityEngine;

public class KillAllWinCondition : WinConditionChecker
{
    [SerializeField] private EnemySpawner spawner;
    public override bool IsConditionReached()
    {
        if (spawner.RemainingEnemies <= 0)
        {
            return true;
        }
        return false;
    }
}
