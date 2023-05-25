using UnityEngine;

public class WeaponByEnemyDirection : WeaponBase
{
    [Header("SettingsByEnemyDirection")]
    [SerializeField] private float _radiusDetection;
    [SerializeField] private LayerMask _enemylayerMask;
    public override void Attack()
    {
        var target = Physics2D.OverlapCircle(player.transform.position, _radiusDetection, _enemylayerMask);
        if (target == null)
        {
            return;
        }
        GameObject weapon = Instantiate(weaponData.bulletPrefab, player.transform.position, Quaternion.identity);
        weapon.GetComponent<Rigidbody2D>().velocity = (target.transform.position - player.transform.position) * weaponStats.speedWeapon;
        ProjectileSettings(weapon);
    }
}
