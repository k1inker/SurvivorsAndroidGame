using System;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
    }
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string nameItem;
    public ItemStats stats;
    public UpgradeData[] upgrades;
    public Item(string name)
    {
        nameItem = name;
        stats = new ItemStats();
        upgrades = new UpgradeData[0];
    }
    public void Equip(CharacterStatsManager playerStats)
    {
        playerStats.armor += stats.armor;
    }
    public void UnEquip(CharacterStatsManager playerStats)
    {
        playerStats.armor -= stats.armor;
    }
}
