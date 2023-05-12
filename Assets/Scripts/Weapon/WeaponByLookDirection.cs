using UnityEngine;

// for weapons that shoot ahead of the player
[CreateAssetMenu(menuName ="Weapon/LookDirectionWeapon")]
public class WeaponByLookDirection : Weapon
{
    public override void SpawnWeapon(PlayerManager player)
    {
        GameObject weapon = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        weapon.GetComponent<Rigidbody2D>().velocity = player.lookDirection * speedWeapon;
        ProjectileSettings(weapon);
    }
    protected override void ProjectileSettings(GameObject weapon)
    {
        base.ProjectileSettings(weapon);
    }
}
