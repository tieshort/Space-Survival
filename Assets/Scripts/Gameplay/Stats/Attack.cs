using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isAttacking;

    [SerializeField] private AttackStrategy[] attackStrategies;

    public float AdditionalBaseDamage { get; set; } = 0f;
    public float DamageMultiplier { get; set; } = 1f;

    public float AttackSpeedMultiplier { get; set; } = 1f;

    protected virtual void Update()
    {
        foreach (var strategy in attackStrategies) 
        { 
            strategy.isAttacking = isAttacking;
        }
    }
}
