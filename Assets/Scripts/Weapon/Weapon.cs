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
    public abstract void SpawnWeapon(PlayerManager player);
    protected virtual void BulletSettings(GameObject weapon)
    {
        DamageCollision settingsBullet = weapon.GetComponent<DamageCollision>();

        settingsBullet.isThrough = isThrough;
        settingsBullet.isPushBack = isPushBack;

        settingsBullet.damage = damageWeapon;
        settingsBullet.pushBackForce = pushBackForce;

        settingsBullet.DestoyTimer(timeAlive);
    }
}
public interface IWeapon
{
    public void PathBullet();
}
