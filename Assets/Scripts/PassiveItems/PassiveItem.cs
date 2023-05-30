using System;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();

    private CharacterManager _character;
    private void Awake()
    {
        _character = GetComponent<CharacterManager>();
    }
    public void Equip(Item itemToEquip)
    {
        Item newItemInstance = new Item(itemToEquip.nameItem);
        newItemInstance.stats.Sum(itemToEquip.stats);

        _items.Add(newItemInstance);
        newItemInstance.Equip(_character);
    }

    public void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = _items.Find(id => id.nameItem == upgradeData.item.nameItem);
        itemToUpgrade.UnEquip(_character);
        itemToUpgrade.stats.Sum(upgradeData.itemUpgradeStats);
        itemToUpgrade.Equip(_character);
    }
}
