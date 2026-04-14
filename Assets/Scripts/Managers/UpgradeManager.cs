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
        //LoadUpgrade(upgradeInstance);
    }

    public void LoadUpgrades()
    {

    }
}
