using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerManager _playerManager;
    public Slider _slider { get; private set; }
    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _playerManager = GetComponentInParent<PlayerManager>();
    }
    private void Start()
    {
        _playerManager.playerStatsManager.OnTakeDamagePlayer += SetHealthValue;
    }
    public void SetMaxHealthValue(int maxHealth)
    {
        _slider.maxValue = maxHealth;
    }
    public void SetHealthValue(int currentHealth)
    {
        _slider.value = currentHealth;
    }

}
