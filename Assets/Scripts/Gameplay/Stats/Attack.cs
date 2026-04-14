using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    public bool isAttacking;

    [SerializeField] private AttackStrategy[] attackStrategies;

    protected virtual void Update()
    {
        foreach (var strategy in attackStrategies) 
        { 
            strategy.isAttacking = isAttacking;
        }
    }
}
