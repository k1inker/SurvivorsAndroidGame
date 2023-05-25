using UnityEngine;

public class WeaponByLookDirection : WeaponBase
{
    [SerializeField] private float spreadAngle;
    [SerializeField] private float countProjectile;
    public override void Attack()
    {
        for (int i = 0; i < countProjectile; i++)
        {
            // setup random direction spread bullet
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion spreadRotation = Quaternion.Euler(0f, 0f, randomAngle);
            Vector2 bulletDirection = spreadRotation * player.playerWeaponManager.lookDirection;

            GameObject weapon = Instantiate(weaponData.bulletPrefab, player.transform.position, Quaternion.identity);
            weapon.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * weaponStats.speedWeapon;
            ProjectileSettings(weapon);
        }
    }
    protected override void ProjectileSettings(GameObject weapon)
    {
        base.ProjectileSettings(weapon);
    }
}
