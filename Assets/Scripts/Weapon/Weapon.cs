using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected int damageWeapon;
    public float reloadDelay;
    [SerializeField] protected float speedWeapon;
    public abstract void SpawnWeapon(PlayerManager player);
}
public interface IWeapon
{
    public void PathBullet();
}
