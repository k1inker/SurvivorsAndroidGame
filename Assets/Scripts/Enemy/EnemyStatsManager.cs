using System;
using UnityEngine;
using Zenject;

public class EnemyStatsManager : CharacterStatsManager
{
    public Action<Vector2, int> OnTakeDamageEnemy;
    
    [Inject] private DamageIndicatorUI _indicator;

    public Action OnEnemyDeath;
    protected override void Start()
    {
        base.Start();
        OnTakeDamageEnemy += _indicator.SpawnIndicator;
    }
    public override void TakeDamage(int countDamage)
    {
        OnTakeDamageEnemy?.Invoke(transform.position,countDamage);
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
