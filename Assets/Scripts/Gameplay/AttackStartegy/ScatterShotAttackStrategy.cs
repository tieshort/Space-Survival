using UnityEngine;

public class ScatterShotAttackStrategy : MissileAttackStrategy
{
    [SerializeField, Min(1)] protected int multishot = 3; 

    public override void Attack()
    {
        for (int i = 0; i < multishot; i++)
        {
            base.Attack();
        }
    }
}
