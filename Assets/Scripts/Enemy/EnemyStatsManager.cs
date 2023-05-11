using UnityEngine;

public class EnemyStatsManager : CharacterStatsManager
{
    private EnemyManager _enemy;
    protected override void Awake()
    {
        base.Awake();
        _enemy = GetComponent<EnemyManager>();
    }
    public override void TakeDamage(int countDamage)
    {
        base.TakeDamage(countDamage);
        UIDamageIndicator.Instance.SpawnIndicator(transform.position, countDamage);
    }

    public override void HandlerDeath()
    {
        base.HandlerDeath();
        _enemy.SetTargetNull();
        Invoke(nameof(DestroyEnemy), 1f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
