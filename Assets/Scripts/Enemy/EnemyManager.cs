using System.Collections;
using UnityEngine;
using Zenject;

public class EnemyManager : CharacterManager
{
    public EnemyStatsManager enemyStats { get; private set; }
    public EnemyLocomotionManager enemyLocomotion { get; private set; }

    [Header("Damage parametrs")]
    [SerializeField] private float _rateDamage = 0.5f;
    [SerializeField] private int _damage = 1;

    [Header("Information Target")]
    [SerializeField] [Inject] private PlayerManager _currentTarget;
    [SerializeField] private Vector2 _targetVector;

    private Coroutine _dealingDamageCoroutine;
    protected override void Awake()
    {
        base.Awake();
        enemyStats = GetComponent<EnemyStatsManager>();
        enemyLocomotion = GetComponent<EnemyLocomotionManager>();
    }
    private void Start()
    {
        enemyStats.OnEnemyDeath += DeathingHandler;
    }
    private void FixedUpdate()
    {
        enemyLocomotion.HandelMovment(_targetVector);
    }
    private void LateUpdate()
    {
        UpdateInfoTarget();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _currentTarget.gameObject)
        {
            if (_dealingDamageCoroutine == null)
            {
                _dealingDamageCoroutine = StartCoroutine(DealingDamage());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _currentTarget.gameObject)
        {
            if (_dealingDamageCoroutine != null)
            {
                StopCoroutine(_dealingDamageCoroutine);
                _dealingDamageCoroutine = null;
            }
        }
    }
    private void UpdateInfoTarget()
    {
        if(_currentTarget != null)
        {
            _targetVector = _currentTarget.transform.position - transform.position;
            _targetVector.Normalize();
        }
    }
    public void DeathingHandler()
    {
        if(_dealingDamageCoroutine != null)
            StopCoroutine(_dealingDamageCoroutine);
        _targetVector = Vector2.zero;
    }
    private IEnumerator DealingDamage()
    {
        while (true)
        {
            if(_currentTarget != null)
                _currentTarget.playerStatsManager.TakeDamage(_damage);
            yield return new WaitForSeconds(_rateDamage);
        }
    }
}
