using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public float reloadDelay;
    [Header("Flags")]
    [SerializeField] protected bool isThrough;
    [SerializeField] protected bool isPushBack;

    [Header("Value")]
    [SerializeField] protected int damageWeapon;
    [SerializeField] protected float speedWeapon;
    [SerializeField] protected float timeAlive;
    [SerializeField] protected float pushBackForce;

    [Header("Prefab")]
    [SerializeField] protected GameObject bulletPrefab;

    [Header("Upgrades")]
    public List<UpgradeData> upgradesData;
    public abstract void SpawnWeapon(PlayerManager player);
    protected virtual void ProjectileSettings(GameObject weapon)
    {
        Projectile projectile = weapon.GetComponent<Projectile>();

        projectile.SettingsProjectile(damageWeapon, isThrough, isPushBack, pushBackForce, timeAlive);
    }
}
public interface IWeapon
{
    public void PathBullet();
}
