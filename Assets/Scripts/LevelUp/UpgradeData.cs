using UnityEngine;

public enum UpgradeType
{
    WeaponUnlock,
    WeaponUpgrade,
    ItemUnlock,
    ItemUpgrade
}
[CreateAssetMenu(menuName = "Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string enhancementContext;
    public UpgradeType upgradeType;
    public Sprite icon;

    public WeaponData weaponData;
    public Item item;

    [Header("Upgrade Simple Stats")]
    public WeaponStats weaponUpgradeStats;
    public ItemStats itemUpgradeStats;
}
