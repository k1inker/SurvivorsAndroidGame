using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [SerializeField] private LayerMask _enemylayerMask;

    [SerializeField] private float _radiusExplosion;
    private void Awake()
    {
        if(isThrough)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    public void SettingsProjectile(int damage, bool isThrough, bool isPushBack, float pushBackForce,float timeAlive, float radiusExplosion)
    {
        base.SettingsProjectile(damage, isThrough, isPushBack, pushBackForce, timeAlive);
        _radiusExplosion = radiusExplosion;
    }
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
        DestoyProjectile();
    }
}
