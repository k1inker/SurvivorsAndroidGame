using UnityEngine;

public class SimpleProjectile : Projectile
{
    public override void ActionAtTheDestinationPoint()
    {
        DestoyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ConstantName.Tags.Enemy)
        {
            CharacterManager character = collision.GetComponent<CharacterManager>();
            character.characterStatsManager.TakeDamage(damage);

            if (isPushBack)
            {
                Vector2 directionPush = collision.transform.position - transform.position;
                character.characterLocomotionManager.KnockBack(directionPush.normalized, pushBackForce);
            }
            if (!isThrough)
            {
                ActionAtTheDestinationPoint();
            }
        }
    }
}
