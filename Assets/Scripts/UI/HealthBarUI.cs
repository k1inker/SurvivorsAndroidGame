using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Inject] private PlayerManager _playerManager;

    [SerializeField] private Slider _healthBar;

    private void Start()
    {
        _playerManager.playerStatsManager.OnMaxHealthChange += SetMaxHealthValue;
        _playerManager.playerStatsManager.OnHealthChange += SetHealthValue;
    }
    public void SetMaxHealthValue(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
    }
    public void SetHealthValue(int currentHealth)
    {
        _healthBar.value = currentHealth;
    }
}
