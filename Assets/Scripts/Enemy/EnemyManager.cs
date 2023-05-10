using System.Collections;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    public EnemyStatsManager enemyStats { get; private set; }
    public EnemyLocomotionManager enemyLocomotion { get; private set; }

    [Header("Param damage")]
    [SerializeField] private int _damage = 1;
    [Range(0.5f, 5f)]
    [SerializeField] private float _rateDamage = 0.5f;

    [Header("Information Target")]
    [SerializeField] private PlayerManager _currentTarget;
    [SerializeField] private Vector2 _targetVector;

    private Coroutine dealingDamageCoroutine;
    protected override void Awake()
    {
        base.Awake();
        enemyStats = GetComponent<EnemyStatsManager>();
        enemyLocomotion = GetComponent<EnemyLocomotionManager>();
        _currentTarget = PlayerManager.Instance;
    }
    private void Update()
    {
        UpdateInfoTarget();
    }
    private void FixedUpdate()
    {
        enemyLocomotion.HandelMovment(_targetVector);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (dealingDamageCoroutine == null)
            {
                dealingDamageCoroutine = StartCoroutine(DealingDamage());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (dealingDamageCoroutine != null)
            {
                StopCoroutine(dealingDamageCoroutine);
                dealingDamageCoroutine = null;
            }
        }
    }
    private void UpdateInfoTarget()
    {
        if(_currentTarget != null)
        {
            _targetVector = _currentTarget.transform.position - transform.position;
        }
    }
    public void SetTargetNull()
    {
        _currentTarget = null;
    }
    private IEnumerator DealingDamage()
    {
        while (true)
        {
            PlayerManager.Instance.playerStatsManager.TakeDamage(_damage);
            yield return new WaitForSeconds(_rateDamage);
        }
    }
}
