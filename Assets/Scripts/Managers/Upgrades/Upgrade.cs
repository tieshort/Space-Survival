using UnityEngine;

public abstract class Upgrade: ScriptableObject
{
    public void Apply(float value, Health target, UpgradeType upgradeType)
    {

    }

    public void Apply(float value, Movement target, UpgradeType upgradeType) 
    { 

    }

    public void Apply(float value, Attack target, UpgradeType upgradeType)
    {

    }
}

public enum UpgradeType
{
    Override,
    Additive,
    Multiplicative,
}