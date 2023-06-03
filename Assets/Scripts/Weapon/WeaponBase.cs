using System;
using System.Collections;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData { get; private set; }
    protected WeaponStats weaponStats { get; private set; }
    protected PlayerManager player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerManager>();
    }
    private void Start()
    {
        StartCoroutine(StartAttack());
    }
    private void FixedUpdate()
    {
        if (this is IWeaponPath)
        {
            IWeaponPath iWeapon = (IWeaponPath)this;
            iWeapon.PathBullet();
        }
    }
    public abstract void Attack();
    private IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < weaponStats.countAttack; i++)
            {
                Attack();
                yield return new WaitForSeconds(.3f);
            }
            yield return new WaitForSeconds(weaponStats.reloadDelay);
        }
    }
    public void StopAttack()
    {
        StopAllCoroutines();
    }
    public void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.weaponStats.isThrough, wd.weaponStats.isPushBack, wd.weaponStats.reloadDelay,
            wd.weaponStats.countAttack, wd.weaponStats.damageWeapon, wd.weaponStats.speedWeapon, wd.weaponStats.timeAlive,
            wd.weaponStats.pushBackForce);
    }
    protected virtual void ProjectileSettings(GameObject weapon)
    {
        Projectile projectile = weapon.GetComponent<Projectile>();

        projectile.SettingsProjectile(weaponStats, player.transform);
    }
    public void AddStatsWeapon(WeaponStats upgradeStats)
    {
        weaponStats.SumSimpleStats(upgradeStats);
    }
}
