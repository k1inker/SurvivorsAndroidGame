using UnityEngine;

public class SimpleProjectile : Projectile
{
    public override void ActionAtTheDestinationPoint()
    {
        DestoyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableObject = collision.GetComponent<IDamageable>();

        if (damageableObject == null)
            return;

        if (isPushBack)
        {
            CharacterMovement character = collision.GetComponent<CharacterMovement>();
            if (character != null)
            {
                Vector2 directionPush = collision.transform.position - transformPlayer.position;
                character.KnockBack(directionPush.normalized, pushBackForce);
            }
        }
        damageableObject.TakeDamage(damage);   

        if (!isThrough)
        {
            ActionAtTheDestinationPoint();
        }
        
    }
}
