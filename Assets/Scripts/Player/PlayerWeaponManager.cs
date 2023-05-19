using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<Weapon> weapons;
    public Vector2 lookDirection { get; private set; } = Vector2.down;
    private PlayerManager _player;
    private void Awake()
    {
        _player = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        foreach(Weapon w in weapons)
        {
            _player.playerLevelManager.SetStartUpgrades(w);
        }
        StartAttackAllWeapons();
    }
    private void Update()
    {
        if (_player.inputHandler.moveInput != Vector2.zero)
            lookDirection = _player.inputHandler.moveInput;
    }
    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        StopAllCoroutines();
        StartAttackAllWeapons();
    }
    public void PathBulletControler()
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon is IWeaponPath)
            {
                IWeaponPath iWeapon = (IWeaponPath)weapon;
                iWeapon.PathBullet();
            }
        }
    }
    private void StartAttackAllWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            StartCoroutine(Attack(weapon));
        }
    }
    private IEnumerator Attack(Weapon currentWeapon)
    {
        while (true)
        {
            yield return new WaitForSeconds(currentWeapon.weaponStats.reloadDelay);
            for (int i = 0; i < currentWeapon.weaponStats.countWeapons; i++)
            {
                currentWeapon.SpawnWeapon(_player);
                yield return new WaitForSeconds(.3f);
            }
        }
    }
    public void UpgradeWeapon(UpgradeData upgradeData)
    {
        Weapon weaponToUpgrade = weapons.Find(weapon => weapon == upgradeData.weaponData);
        weaponToUpgrade.weaponStats.UpgradeStats(upgradeData.upgradeStats);
    }
}
