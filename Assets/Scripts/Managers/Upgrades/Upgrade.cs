using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUpgrade", menuName = "Upgrade Instance/Upgrade")]
public class Upgrade : ScriptableObject
{
    public StatUpgrade healthUpgrade;
    public StatUpgrade movementUpgrade;
    public StatUpgrade rotationUpgrade;

    public StatUpgrade damageUpgrade;
    public StatUpgrade attackSpeedUpgrade;
}
[System.Serializable]
public struct StatUpgrade
{
    public float AdditionalBaseValue;
    public float ValueMultiplier;
}
