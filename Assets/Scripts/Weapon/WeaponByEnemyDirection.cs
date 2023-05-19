using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/EnemyDirectionWeapon")]
public class WeaponByEnemyDirection : Weapon
{
    [Header("SettingsByEnemyDirection")]
    [SerializeField] private float _radiusDetection;
    [SerializeField] private LayerMask _enemylayerMask;
    public override void SpawnWeapon(PlayerManager player)
    {
        var target = Physics2D.OverlapCircle(player.transform.position, _radiusDetection, _enemylayerMask);
        if (target == null)
        {
            return;
        }
        GameObject weapon = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        weapon.GetComponent<Rigidbody2D>().velocity = (target.transform.position - player.transform.position) * weaponStats.speedWeapon;
        ProjectileSettings(weapon);
    }
}
