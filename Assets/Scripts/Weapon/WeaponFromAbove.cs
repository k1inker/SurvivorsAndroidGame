using UnityEngine;

public class WeaponFromAbove : WeaponBase, IWeaponPath
{
    [Header("SettingsFromAboveWeapon")]
    [SerializeField] private float _radiusPotentialDrop;
    [SerializeField] private float _radiusExplosion;

    private Vector2 _destinationPoint;
    private Rigidbody2D _rb;
    private Projectile _projectile;
    public void PathBullet()
    {
        if(_rb == null)
        {
            return;
        }

        _rb.MovePosition(_rb.transform.position + Vector3.down * weaponStats.speedWeapon);

        if(_rb.transform.position.y <= _destinationPoint.y)
        {
            _projectile.ActionAtTheDestinationPoint();
        }
    }

    public override void Attack()
    {
        // get top screen point 
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).y;

        // get a random point in the radius around the player's position
        Vector3 randomOffset = Random.insideUnitCircle.normalized * _radiusPotentialDrop;
        _destinationPoint = player.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
       
        Vector2 spawnPosition = new Vector2(_destinationPoint.x, screenTop);
        GameObject projectile = Instantiate(weaponData.bulletPrefab, spawnPosition, Quaternion.identity);

        //settings explosive projectile
        _rb = projectile.GetComponent<Rigidbody2D>();
        _projectile = projectile.GetComponent<Projectile>();
        _projectile.SettingsProjectile(weaponStats);
    }
}
