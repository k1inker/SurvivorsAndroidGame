using UnityEngine;

// for weapons that shoot ahead of the player
[CreateAssetMenu(menuName ="Weapon/DirectionWeapon")]
public class WeaponByDirection : Weapon
{
    public override void SpawnWeapon(PlayerManager player)
    {
        GameObject weapon = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        weapon.GetComponent<Rigidbody2D>().velocity = player.lookDirection * speedWeapon;
        weapon.GetComponent<DirectionPathHandler>().damage = damageWeapon;
    }
}
