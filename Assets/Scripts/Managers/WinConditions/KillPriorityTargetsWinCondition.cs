using UnityEngine;

public class KillPriorityTargetsWinCondition : WinConditionChecker
{
    [SerializeField] private GameObject[] priorityTargets;
    public override bool IsConditionReached()
    {
        for (int i = 0; i < priorityTargets.Length; i++)
        {
            if (priorityTargets[i].activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
