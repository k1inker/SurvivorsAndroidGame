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
        if (collision.tag == ConstantName.Tags.Enemy)
        {
            ActionAtTheDestinationPoint();
        }
    }

    public override void ActionAtTheDestinationPoint()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _radiusExplosion, _enemylayerMask))
        {
            CharacterManager character = collider.GetComponent<CharacterManager>();
            if (isPushBack)
            {
                character.characterLocomotionManager.KnockBack(character.transform.position - transform.position, pushBackForce);
            }
            character.characterStatsManager.TakeDamage(damage);
        }
        Instantiate(_effectExplosion, transform.position, Quaternion.identity);
        DestoyProjectile();
    }
}
