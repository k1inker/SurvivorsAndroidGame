using System;
using UnityEngine;
using Zenject;
public class EnemyStatsManager : CharacterStatsManager, IDamageable
{
    [Inject] private DamageIndicatorUI _indicator;

    public Action OnEnemyDeath;
    public void ApplyProgress(float progress)
    {
        maxHealth = maxHealth + (int)(maxHealth * progress);
    }
    public override void TakeDamage(int countDamage)
    {
        if (currentHealth <= 0)
            return;

        _indicator.SpawnIndicator(transform.position,countDamage);
        base.TakeDamage(countDamage);
    }
    public override void HandlerDeath()
    {
        base.HandlerDeath();
        OnEnemyDeath?.Invoke();
        Invoke(nameof(DestroyEnemy), 1f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
