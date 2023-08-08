using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Weapon/ByLookDirection")]
public class WeaponByLookDirection : WeaponData
{
    private float radius = .3f;
    public override void Attack(PlayerWeaponManager weaponManager)
    {
        foreach (var spawn in GetArraySpawnsInfo(weaponManager))
        {
            GameObject weapon = Instantiate(bulletPrefab, spawn.Key, spawn.Value, weaponManager.transform);
            ProjectileSettings(weapon, weaponManager.transform);
        }
    }
    private Dictionary<Vector2, Quaternion> GetArraySpawnsInfo(PlayerWeaponManager weaponManager)
    {
        Dictionary<Vector2, Quaternion> valuePairs = new Dictionary<Vector2, Quaternion>();
        float differenceRotationZ = 360 / weaponStats.countAttack;
        for (int i = 0; i < weaponStats.countAttack; i++)
        {
            float spawnRotationZ = Mathf.Atan2(weaponManager.lookDirection.y, weaponManager.lookDirection.x) * Mathf.Rad2Deg;
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnRotationZ + differenceRotationZ * i);

            Vector2 spawnDirection = new Vector2(Mathf.Cos(spawnRotationZ * Mathf.Deg2Rad), Mathf.Sin(spawnRotationZ * Mathf.Deg2Rad));
            Vector2 spawnPosition = new Vector2(weaponManager.transform.position.x + spawnDirection.x * radius,
                                                weaponManager.transform.position.y + spawnDirection.y * radius);

            if (!valuePairs.ContainsKey(spawnPosition))
            {
                valuePairs.Add(spawnPosition, spawnRotation);
            }
        }
        return valuePairs;
    }
}
