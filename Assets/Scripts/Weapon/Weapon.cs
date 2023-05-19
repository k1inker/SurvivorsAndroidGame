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
    public int countWeapons = 1;
    public int damageWeapon;
    public float speedWeapon;
    public float timeAlive;
    public float pushBackForce;

    public void UpgradeStats(WeaponStats aditionalStats)
    {
        this.isThrough = aditionalStats.isThrough;
        this.isPushBack = aditionalStats.isPushBack;

        this.reloadDelay += aditionalStats.reloadDelay;
        this.countWeapons += aditionalStats.countWeapons;
        this.damageWeapon += aditionalStats.damageWeapon;
        this.speedWeapon += aditionalStats.speedWeapon;
        this.timeAlive += aditionalStats.timeAlive;
        this.pushBackForce += aditionalStats.pushBackForce;
    }
}
public abstract class Weapon : ScriptableObject
{
    [Header("Stats")]
    public WeaponStats weaponStats;

    [Header("Prefab")]
    [SerializeField] protected GameObject bulletPrefab;

    [Header("Upgrades")]
    public List<UpgradeData> upgradesData;
    public abstract void SpawnWeapon(PlayerManager player);
    protected virtual void ProjectileSettings(GameObject weapon)
    {
        Projectile projectile = weapon.GetComponent<Projectile>();

        projectile.SettingsProjectile(weaponStats);
    }
    public virtual void AddStatsWeapon(WeaponStats addStats)
    {
        weaponStats.damageWeapon += addStats.damageWeapon;
        weaponStats.countWeapons += addStats.countWeapons;
        weaponStats.speedWeapon += addStats.speedWeapon;
        weaponStats.timeAlive += addStats.timeAlive;
        weaponStats.pushBackForce += addStats.pushBackForce;
    }
}
public interface IWeaponPath
{
    public void PathBullet();
}
