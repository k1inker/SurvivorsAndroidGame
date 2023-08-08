using UnityEngine;
public class ExplosiveProjectile : Projectile
{
    [SerializeField] private float _radiusExplosion;

    [SerializeField] private GameObject _effectExplosion;
    protected override void Awake()
    {
        base.Awake();
        if(isThrough)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() == null)
            return;

        ActionAtTheDestinationPoint();
    }

    public override void ActionAtTheDestinationPoint()
    {
        Instantiate(_effectExplosion, transform.position, Quaternion.identity);
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _radiusExplosion))
        {
            if (isPushBack)
            {
                CharacterMovement character = collider.GetComponent<CharacterMovement>();
                if(character != null)
                    character.KnockBack(collider.transform.position - transform.position, pushBackForce);
            }
            IDamageable damageableObject = collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(damage);
            }
        }
        destroyHandler.DestroyObject();
    }
}
