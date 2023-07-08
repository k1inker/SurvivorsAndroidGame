using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();

    private CharacterStatsManager _characterStats;
    private void Awake()
    {
        _characterStats = GetComponent<CharacterStatsManager>();
    }
    public void Equip(Item itemToEquip)
    {
        Item newItemInstance = new Item(itemToEquip.nameItem);
        newItemInstance.stats.Sum(itemToEquip.stats);

        _items.Add(newItemInstance);
        newItemInstance.Equip(_characterStats);
    }

    public void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = _items.Find(id => id.nameItem == upgradeData.item.nameItem);
        itemToUpgrade.UnEquip(_characterStats);
        itemToUpgrade.stats.Sum(upgradeData.itemUpgradeStats);
        itemToUpgrade.Equip(_characterStats);
    }
}
