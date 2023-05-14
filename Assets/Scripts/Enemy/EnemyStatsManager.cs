using System;
using UnityEngine;
using Zenject;

public class EnemyStatsManager : CharacterStatsManager
{
    public Action<Vector2, int> OnTakeDamageEnemy;
    
    [Inject] private UIDamageIndicator _indicator;

    private EnemyManager _enemy;
    protected void Awake()
    {
        _enemy = GetComponent<EnemyManager>();
    }
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
        _enemy.SetTargetNull();
        Invoke(nameof(DestroyEnemy), 1f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
