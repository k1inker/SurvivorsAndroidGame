using UnityEngine;

// for weapons that shoot ahead of the player
[CreateAssetMenu(menuName ="Weapon/LookDirectionWeapon")]
public class WeaponByLookDirection : Weapon
{
    [SerializeField] private int countBullet;
    [SerializeField] private float spreadAngle;
    public override void SpawnWeapon(PlayerManager player)
    {
        for (int i = 0; i < countBullet; i++)
        {
            // setup random direction spread bullet
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion spreadRotation = Quaternion.Euler(0f, 0f, randomAngle);
            Vector2 bulletDirection = spreadRotation * player.playerWeaponManager.lookDirection;

            GameObject weapon = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
            weapon.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * weaponStats.speedWeapon;
            ProjectileSettings(weapon);
        }
    }
    protected override void ProjectileSettings(GameObject weapon)
    {
        base.ProjectileSettings(weapon);
    }
}
