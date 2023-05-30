using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class WeaponStats
{
    [Header("Flags")]
    public bool isThrough;
    public bool isPushBack;

    [Header("Value")]
    public float reloadDelay;
    public int countAttack = 1;
    public int damageWeapon;
    public float speedWeapon;
    public float timeAlive = 6;
    public float pushBackForce;

    public WeaponStats(bool isThrough, bool isPushBack, float reloadDelay, int countWeapons, int damageWeapon, float speedWeapon, float timeAlive, float pushBackForce)
    {
        this.isThrough = isThrough;
        this.isPushBack = isPushBack;
        this.reloadDelay = reloadDelay;
        this.countAttack = countWeapons;
        this.damageWeapon = damageWeapon;
        this.speedWeapon = speedWeapon;
        this.timeAlive = timeAlive;
        this.pushBackForce = pushBackForce;
    }

    internal void SumSimpleStats(WeaponStats upgradeStats)
    {
        reloadDelay -= upgradeStats.reloadDelay;
        countAttack += upgradeStats.countAttack;
        damageWeapon += upgradeStats.damageWeapon;
        speedWeapon += speedWeapon;
        timeAlive += upgradeStats.timeAlive;
        pushBackForce += upgradeStats.pushBackForce;
    }
}
[CreateAssetMenu(menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public WeaponStats weaponStats;

    [Header("Prefab")]
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public GameObject weaponBasePrefab;

    [Header("Upgrades")]
    public UpgradeData[] upgradesData;
}