using UnityEngine;

public class WeaponByEnemyDirection : WeaponBase
{
    [Header("SettingsByEnemyDirection")]
    [SerializeField] private float _radiusDetection;
    [SerializeField] private LayerMask _enemylayerMask;
    [SerializeField] private float spreadAngle;
    [SerializeField] private float countProjectile;
    public override void Attack()
    {
        var target = Physics2D.OverlapCircle(player.transform.position, _radiusDetection, _enemylayerMask);
        if (target == null)
        {
            return;
        }
        for (int i = 0; i < countProjectile; i++)
        {
            // setup random direction spread bullet
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion spreadRotation = Quaternion.Euler(0f, 0f, randomAngle);
            Vector2 bulletDirection = spreadRotation * (target.transform.position - player.transform.position);
            GameObject weapon = Instantiate(weaponData.bulletPrefab, player.transform.position, Quaternion.identity);
            weapon.GetComponent<Rigidbody2D>().velocity = bulletDirection * weaponStats.speedWeapon;
            ProjectileSettings(weapon);
        }
    }
}
