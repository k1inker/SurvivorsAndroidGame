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

        if (collision.GetComponent<IDamageable>() == null)
            return;

        if (isPushBack)
        {
            CharacterLocomotionManager character = collision.GetComponent<CharacterLocomotionManager>();
            if (character != null)
            {
                Vector2 directionPush = collision.transform.position - transformPlayer.position;
                character.KnockBack(directionPush.normalized, pushBackForce);
            }
        }
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
        }    

        if (!isThrough)
        {
            ActionAtTheDestinationPoint();
        }
        
    }
}
