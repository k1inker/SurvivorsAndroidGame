using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ManagerUI : MonoBehaviour
{
    [Inject] private PlayerManager _playerManager;
    [Inject] private StageEventManager _stageManager;

    [SerializeField] private TextMeshProUGUI _timer;

    [Header("Slider bars")]
    [SerializeField] private Slider _experienceBar;
    [SerializeField] private Slider _healthBar;

    [Header("Upgrade Panel")]
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Image[] _upgradeButtons;
    [SerializeField] private TextMeshProUGUI _upgradeText;

    private string[] contextUpgrades;
    private int selectedUpgradeButton = 0;
    private void Awake()
    {
        _playerManager.playerStatsManager.OnMaxHealthChange += SetMaxHealthValue;
        _playerManager.playerStatsManager.OnHealthChange += SetHealthValue;

        _playerManager.playerLevelManager.OnLevelUp += SetMaxExperienceValue;
        _playerManager.playerLevelManager.OnExperienceChange += SetExperienceValue;

        _playerManager.playerLevelManager.OnChooseUpgrade += ShowUpgradePanel;

        _stageManager.OnTimeChange += SetTime;
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
    public void ShowUpgradePanel(UpgradeData[] upgradeDatas)
    {
        contextUpgrades = new string[upgradeDatas.Length];
        for(int i = 0; i < upgradeDatas.Length; i++)
        {
            _upgradeButtons[i].gameObject.SetActive(true);
            _upgradeButtons[i].sprite = upgradeDatas[i].icon;
            contextUpgrades[i] = upgradeDatas[i].enhancementContext;
        }
        UpgradeButtonClick(0);
        PauseManager.PauseGame();
        _upgradePanel.SetActive(true);
    }
    public void UpgradeButtonClick(int idButton)
    {
        _upgradeButtons[idButton].GetComponent<Button>().interactable = false;
        _upgradeText.text = contextUpgrades[idButton];
        selectedUpgradeButton = idButton;
    }
    public void ApplyUpdate()
    {
        for (int i = 0; i < _upgradeButtons.Length; i++)
        {
            _upgradeButtons[i].gameObject.SetActive(false);
        }
        _playerManager.playerLevelManager.Upgrade(selectedUpgradeButton);
        _upgradePanel.SetActive(false);
        PauseManager.ResumeGame();
    }
    public void SetTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        _timer.text = minutes.ToString() + ":" + seconds.ToString("00");
    }
}
