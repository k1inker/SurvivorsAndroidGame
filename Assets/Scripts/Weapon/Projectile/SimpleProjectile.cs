using UnityEngine;

public class SimpleProjectile : Projectile
{
    public override void ActionAtTheDestinationPoint()
    {
        DestoyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != ConstantName.Tags.Enemy)
            return;

        EnemyManager enemy = collision.GetComponent<EnemyManager>();
        enemy.characterStatsManager.TakeDamage(damage);

        if (isPushBack)
        {
            Vector2 directionPush = collision.transform.position - transformPlayer.position;
            enemy.enemyLocomotion.KnockBack(directionPush.normalized, pushBackForce);
        }
        if (!isThrough)
        {
            ActionAtTheDestinationPoint();
        }
        
    }
}
