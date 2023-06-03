using System.Collections.Generic;
using UnityEngine;

public class WeaponByLookDirection : WeaponBase
{
    private float radius = .3f;
    public override void Attack()
    {
        foreach (var spawn in GetArraySpawnsInfo())
        {
            GameObject weapon = Instantiate(weaponData.bulletPrefab, spawn.Key, spawn.Value, this.transform);
            ProjectileSettings(weapon);
        }
    }
    private Dictionary<Vector2, Quaternion> GetArraySpawnsInfo()
    {
        Dictionary<Vector2, Quaternion> valuePairs = new Dictionary<Vector2, Quaternion>();
        float differenceRotationZ = 360 / weaponStats.countAttack;
        for (int i = 0; i < weaponStats.countAttack; i++)
        {
            float spawnRotationZ = Mathf.Atan2(player.playerWeaponManager.lookDirection.y, player.playerWeaponManager.lookDirection.x) * Mathf.Rad2Deg;
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, spawnRotationZ + differenceRotationZ * i);

            Vector2 spawnDirection = new Vector2(Mathf.Cos(spawnRotationZ * Mathf.Deg2Rad), Mathf.Sin(spawnRotationZ * Mathf.Deg2Rad));
            Vector2 spawnPosition = new Vector2(player.transform.position.x + spawnDirection.x * radius,
                                                player.transform.position.y + spawnDirection.y * radius);

            if (!valuePairs.ContainsKey(spawnPosition))
            {
                valuePairs.Add(spawnPosition, spawnRotation);
            }
        }
        return valuePairs;
    }
}
