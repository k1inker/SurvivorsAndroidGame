using NTC.Global.Pool;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [Header("Flags")]
    [SerializeField] private bool _startOnAwake = false;
    [SerializeField] private bool _isDestroyByTime;
    [SerializeField] private bool _isPoolObject;

    [SerializeField] private float _timeAlive;
    private void Awake()
    {
        if (_startOnAwake)
        {
            _timeAlive = Time.time + _timeAlive;
        }
        else
        {
            _isDestroyByTime = false;
        }
    }
    private void OnEnable()
    {
        if (_startOnAwake)
        {
            _timeAlive = Time.time + _timeAlive;
        }
        else
        {
            _isDestroyByTime = false;
        }
    }
    public void Initialize(float timeAlive,bool isPoolObject,bool isDestroyByTime)
    {
        _timeAlive = Time.time + timeAlive;
        _isPoolObject = isPoolObject;
        _isDestroyByTime = isDestroyByTime;
    }
    private void FixedUpdate()
    {
        if (!_isDestroyByTime)
            return;

        if(Time.time > _timeAlive)
        {
            DestroyObject();
        }
    }
    public void DestroyObject()
    {
        if (_isPoolObject)
        {
            NightPool.Despawn(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
