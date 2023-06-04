using UnityEngine;
public class ExplosiveProjectile : Projectile
{
    [SerializeField] private LayerMask _enemylayerMask;

    [SerializeField] private float _radiusExplosion;

    [SerializeField] private GameObject _effectExplosion;
    private void Awake()
    {
        if(isThrough)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    //public void SettingsProjectile(WeaponStats weaponStats, float radiusExplosion)
    //{
    //    base.SettingsProjectile(weaponStats);
    //    _radiusExplosion = radiusExplosion;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() == null)
            return;

        ActionAtTheDestinationPoint();
    }

    public override void ActionAtTheDestinationPoint()
    {
        Instantiate(_effectExplosion, transform.position, Quaternion.identity);
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _radiusExplosion, _enemylayerMask))
        {
            if (isPushBack)
            {
                CharacterLocomotionManager character = collider.GetComponent<CharacterLocomotionManager>();
                if(character != null)
                    character.KnockBack(collider.transform.position - transform.position, pushBackForce);
            }
            IDamageable damageableObject = collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(damage);
            }
        }
        DestoyProjectile();
    }
}
