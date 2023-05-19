using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected int damage;
    protected bool isThrough;
    protected bool isPushBack;
    protected float pushBackForce;
    public void SettingsProjectile(WeaponStats weaponStats)
    {
        damage = weaponStats.damageWeapon;
        isThrough = weaponStats.isThrough;
        isPushBack = weaponStats.isPushBack;
        pushBackForce = weaponStats.pushBackForce;
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
