using UnityEngine;

public abstract class Upgrade: ScriptableObject
{
    public abstract void Apply(GameObject target);
}

public enum UpgradeType
{
    Override,
    Additive,
    Multiplicative,
}

public class UpgradeContext
{
    public Health health;
    public Attack attack;
    public Movement movement;
    public Rotation rotation;

    public Upgrade upgradeInstance;
}