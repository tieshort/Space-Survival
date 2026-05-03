using UnityEngine;

public class UpgradeManager: MonoBehaviour
{
    [SerializeField] private Health upgradableHealth;
    [SerializeField] private Attack upgradableAttack;
    [SerializeField] private Movement upgradableMovement;
    [SerializeField] private Rotation upgradableRotation;

    [SerializeField] private Upgrade upgradeInstance;

    private void Start()
    {
        LoadUpgrades();
    }

    public void LoadUpgrades()
    {
        if (upgradeInstance == null) return;

        LoadUpgrade(upgradableHealth);
        LoadUpgrade(upgradableAttack);
        LoadUpgrade(upgradableMovement);
        LoadUpgrade(upgradableMovement);
    }

    public void LoadUpgrade(Health health)
    {
        if (health == null) return;

        health.AdditionalBaseHealth = upgradeInstance.healthUpgrade.AdditionalBaseValue;
        health.HealthMultiplier = upgradeInstance.healthUpgrade.ValueMultiplier;
    }

    public void LoadUpgrade(Attack attack)
    {
        if (attack == null) return;

        attack.AdditionalBaseDamage = upgradeInstance.damageUpgrade.AdditionalBaseValue;
        attack.DamageMultiplier = upgradeInstance.damageUpgrade.ValueMultiplier;

        attack.AttackSpeedMultiplier = upgradeInstance.attackSpeedUpgrade.ValueMultiplier;
    }

    public void LoadUpgrade(Movement movement)
    {
        if (movement == null) return;

        movement.AdditionalBaseSpeed = upgradeInstance.movementUpgrade.AdditionalBaseValue;
        movement.SpeedMultiplier = upgradeInstance.movementUpgrade.ValueMultiplier;
    }

    public void LoadUpgrade(Rotation rotation)
    {
        if (rotation == null) return;

        rotation.AdditionalBaseSpeed = upgradeInstance.rotationUpgrade.AdditionalBaseValue;
        rotation.SpeedMultiplier = upgradeInstance.rotationUpgrade.ValueMultiplier;
    }
}
