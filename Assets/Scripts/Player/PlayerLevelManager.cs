using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerLevelManager : MonoBehaviour
{
    public sbyte level = 0;

    [SerializeField] private int _maxValuePerLevel;
    [SerializeField] private sbyte _multiplayLevel = 2;
    [SerializeField] private List<UpgradeData> upgrades;

    [SerializeField] private int _currentValueOnLevel = 0;
    private List<UpgradeData> selectedUpgrades = new List<UpgradeData>();
    private List<UpgradeData> acquiredUpgrades = new List<UpgradeData>();

    public Action<int> OnExperienceChange;
    public Action<int> OnLevelUp;
    public Action<UpgradeData[]> OnChooseUpgrade;

    private PlayerManager _player;
    private void Awake()
    {
        _player = GetComponent<PlayerManager>();

    }
    private void Start()
    {
        OnExperienceChange += LevelUp;

        OnExperienceChange?.Invoke(_currentValueOnLevel);
        OnLevelUp?.Invoke(_maxValuePerLevel);
    }
    public void IncreaseExperienceValue(int value)
    {
        _currentValueOnLevel += value;
        OnExperienceChange?.Invoke(_currentValueOnLevel);
    }
    public void LevelUp(int currentValue)
    {
        if(currentValue < _maxValuePerLevel)
        {
            return;
        }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        // new current and max values
        int expToNextLevel = currentValue - _maxValuePerLevel;
        _currentValueOnLevel = 0;
        _maxValuePerLevel *= _multiplayLevel;
        level += 1;

        // activating event
        OnLevelUp?.Invoke(_maxValuePerLevel);
        if (selectedUpgrades.Count != 0)
        {
            OnChooseUpgrade?.Invoke(selectedUpgrades.ToArray());
        }

        IncreaseExperienceValue(expToNextLevel);
    }
    private UpgradeData[] GetUpgrades(int count)
    {
        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        UpgradeData[] upgradeArray = new UpgradeData[count];

        for(int i = 0; i < count; i++)
        {
            upgradeArray[i] = upgrades[Random.Range(0, upgrades.Count)];
        }
        return upgradeArray;
    }
    public void UpdateListUpgrades(UpgradeData[] data)
    {
        upgrades.AddRange(data);
    }
    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if(upgradeData.upgradeType == UpgradeType.WeaponUnlock)
        {
            _player.playerWeaponManager.AddWeapon(selectedUpgrades[selectedUpgradeId].weaponData);
            upgrades.AddRange(selectedUpgrades[selectedUpgradeId].weaponData.upgradesData);
        }
        else if(upgradeData.upgradeType == UpgradeType.WeaponUpgrade)
        {
            _player.playerWeaponManager.UpgradeWeapon(selectedUpgrades[selectedUpgradeId]);
        }
        else if(upgradeData.upgradeType == UpgradeType.ItemUnlock)
        {
            _player.passiveItem.Equip(upgradeData.item);
            UpdateListUpgrades(upgradeData.item.upgrades);
        }
        else if(upgradeData.upgradeType == UpgradeType.ItemUpgrade)
        {
            _player.passiveItem.UpgradeItem(upgradeData);
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }
}
