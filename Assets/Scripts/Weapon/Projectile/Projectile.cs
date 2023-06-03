using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected int damage;
    protected bool isThrough;
    protected bool isPushBack;
    protected float pushBackForce;

    protected Transform transformPlayer; // for defenition direction for pushBack
    public void SettingsProjectile(WeaponStats weaponStats, Transform player)
    {
        damage = weaponStats.damageWeapon;
        isThrough = weaponStats.isThrough;
        isPushBack = weaponStats.isPushBack;
        pushBackForce = weaponStats.pushBackForce;
        transformPlayer = player;
        DestoyTimer(weaponStats.timeAlive);
    }
    public abstract void ActionAtTheDestinationPoint();
    private void DestoyTimer(float time)
    {
        Invoke(nameof(DestoyProjectile), time);
    }
    protected void DestoyProjectile()
    {
        Destroy(gameObject);
    }
}
