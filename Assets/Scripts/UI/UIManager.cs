using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerManager _playerManager;

    [Header("Overlay UI")]
    [SerializeField] private Slider _experienceBar;

    [Header("World UI")]
    [SerializeField] private Slider _healthBar;

    private void Awake()
    {
        _playerManager = GetComponentInParent<PlayerManager>();
    }
    private void Start()
    {
        _playerManager.playerStatsManager.OnMaxHealthChange += SetMaxHealthValue;
        _playerManager.playerStatsManager.OnHealthChange += SetHealthValue;

        _playerManager.playerLevelManager.OnLevelUp += SetMaxExperienceValue;
        _playerManager.playerLevelManager.OnExperienceChange += SetExperienceValue;
    }
    public void SetMaxHealthValue(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
    }
    public void SetHealthValue(int currentHealth)
    {
        _healthBar.value = currentHealth;
    }
    public void SetExperienceValue(int currentExp)
    {
        _experienceBar.value = currentExp;
    }
    public void SetMaxExperienceValue(int maxExp)
    {
        _experienceBar.maxValue = maxExp;
    }
}
