using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isAttacking;

    [SerializeField] private AttackStrategy[] attackStrategies;

    public float AdditionalBaseDamage { get; set; }
    public float DamageMultiplier { get; set; }

    public float AttackSpeedMultiplier { get; set; }

    protected virtual void Update()
    {
        foreach (var strategy in attackStrategies) 
        { 
            strategy.isAttacking = isAttacking;
        }
    }
}
