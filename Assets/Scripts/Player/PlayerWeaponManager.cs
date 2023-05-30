using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private Transform parentObjectWeapon;
    [SerializeField] private WeaponData startWeapon;
    public List<WeaponBase> weapons;
    private PlayerManager _player;
    public Vector2 lookDirection { get; private set; } = Vector2.down;
    private void Awake()
    {
        _player = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        AddWeapon(startWeapon);
    }
    private void Update()
    {
        if (_player.inputHandler.moveInput != Vector2.zero)
            lookDirection = _player.inputHandler.moveInput;
    }
    public void AddWeapon(WeaponData weaponData)
    {
        // spawn object
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, parentObjectWeapon);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();
        // set stats for weapon
        weapons.Add(weaponBase);
        weaponBase.SetData(weaponData);

        _player.playerLevelManager.UpdateListUpgrades(weaponData.upgradesData);
    }
    public void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(weapon => weapon.weaponData == upgradeData.weaponData);
        weaponToUpgrade.AddStatsWeapon(upgradeData.weaponUpgradeStats);
    }
}
