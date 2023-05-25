using UnityEngine;

public class WeaponCircular : WeaponBase, IWeaponPath
{
    [Header("Circular Settings")]
    [SerializeField] private float _offsetRadius;

    private Rigidbody2D _rb;
    private PlayerManager _player;

    private float _startTime;
    public void PathBullet()
    {
        if (_rb == null)
            return;

        Vector3 playerPosition = _player.transform.position;

        // Determine the distance from the player at which the projectile should be located
        float timeSinceSpawn = Time.time - _startTime;

        Vector3 offset = Quaternion.Euler(0f, 0f, weaponStats.speedWeapon * timeSinceSpawn) * new Vector3(0f, _offsetRadius, 0f);
        _rb.MovePosition(playerPosition + offset);
    }
    public override void Attack()
    {
        Vector3 spawnPoint = player.transform.position + new Vector3(0f, _offsetRadius, 0f);
        _player = player;
        GameObject projectile = Instantiate(weaponData.bulletPrefab, spawnPoint, Quaternion.identity);
        _rb = projectile.GetComponent<Rigidbody2D>();
        _startTime = Time.time;
        ProjectileSettings(projectile);
    }

}
