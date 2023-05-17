using UnityEngine;

public enum UpgradeType
{
    WeaponUnlock,
    WeaponUpgrade,
    ItamUnlock,
    ItemUpgrade
}
[CreateAssetMenu(menuName = "Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string enhancementContext;
    public UpgradeType upgradeType;
    public Sprite icon;

    public Weapon weaponData;
}
