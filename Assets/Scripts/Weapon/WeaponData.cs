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
    public void SetStatsByWeaponStats(WeaponStats weaponStats)
    {
        isThrough = weaponStats.isThrough;
        isPushBack = weaponStats.isPushBack;
        reloadDelay = weaponStats.reloadDelay;
        countAttack = weaponStats.countAttack;
        damageWeapon = weaponStats.damageWeapon;
        speedWeapon = weaponStats.speedWeapon;
        timeAlive = weaponStats.timeAlive;
        pushBackForce = weaponStats.pushBackForce;
    }
    public void SumSimpleStats(WeaponStats upgradeStats)
    {
        reloadDelay -= upgradeStats.reloadDelay;
        countAttack += upgradeStats.countAttack;
        damageWeapon += upgradeStats.damageWeapon;
        speedWeapon += speedWeapon;
        timeAlive += upgradeStats.timeAlive;
        pushBackForce += upgradeStats.pushBackForce;
    }
}
public abstract class WeaponData : ScriptableObject
{
    [SerializeField] private WeaponStats _initWeaponStats;
    public WeaponStats weaponStats;

    [Header("Prefab")]
    [SerializeField] protected GameObject bulletPrefab;

    [Header("Upgrades")]
    public UpgradeData[] upgradesData;
    public virtual void Initialize()
    {
        weaponStats.SetStatsByWeaponStats(_initWeaponStats);
    }
    protected virtual void ProjectileSettings(GameObject projectile, Transform player)
    {
        Projectile proj = projectile.GetComponent<Projectile>();

        if(proj == null)
            return;

        proj.SetupProjectile(weaponStats, player);
    }
    public abstract void Attack(PlayerWeaponManager weaponManager);
    public virtual void AddStatsWeapon(WeaponStats additionalStats)
    {
        weaponStats.SumSimpleStats(additionalStats);
    }
}