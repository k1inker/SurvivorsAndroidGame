using UnityEngine;
[RequireComponent(typeof(DestroyObjects))]
public abstract class Projectile : MonoBehaviour
{
    protected int damage;
    protected bool isThrough;
    protected bool isPushBack;
    protected float pushBackForce;

    protected Transform transformPlayer; // for defenition direction for pushBack
    protected DestroyObjects destroyHandler;
    protected virtual void Awake()
    {
        destroyHandler = GetComponent<DestroyObjects>();
    }
    public void SetupProjectile(WeaponStats weaponStats, Transform player)
    {
        damage = weaponStats.damageWeapon;
        isThrough = weaponStats.isThrough;
        isPushBack = weaponStats.isPushBack;
        pushBackForce = weaponStats.pushBackForce;
        transformPlayer = player;
        destroyHandler.Initialize(weaponStats.timeAlive,false,true);
    }
    public abstract void ActionAtTheDestinationPoint();
}
