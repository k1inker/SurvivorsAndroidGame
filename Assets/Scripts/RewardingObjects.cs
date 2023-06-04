using UnityEngine;
using Zenject;

public class RewardingObjects : MonoBehaviour, IDamageable
{
    [Inject] private DamageIndicatorUI _indicator;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (_currentHealth < 0)
        {
            Destroy(gameObject);
            return;
        }
        _currentHealth -= damage;
        _indicator.SpawnIndicator(transform.position, damage);
    }
}
