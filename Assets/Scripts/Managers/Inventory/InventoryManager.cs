using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private WeaponSlotData[] weaponSlots;
    [SerializeField] private Sprite lockedSlotSprite;
    [SerializeField] private Sprite unlockedSlotSprite;

    [SerializeField] private int unlockedSlotsCount = 1;

}
[System.Serializable]
public struct WeaponSlotData
{
    public bool isUnlocked;
    public bool isUsed;
    public InstalledWeaponData installedWeaponData;

    [System.Serializable]
    public struct InstalledWeaponData
    {
        public GameObject gameObject;
        public Sprite weaponSprite;
    }
}
