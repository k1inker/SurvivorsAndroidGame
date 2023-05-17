using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ManagerUI : MonoBehaviour
{
    [Inject] private PlayerManager _playerManager;

    [SerializeField] private Slider _experienceBar;

    [Header("Upgrade Panel")]
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Image[] _upgradeButtons;
    [SerializeField] private TextMeshProUGUI _upgradeText;

    private string[] contextUpgrades;
    private int selectedUpgradeButton = 0;
    private void Start()
    {
        _playerManager.playerLevelManager.OnLevelUp += SetMaxExperienceValue;
        _playerManager.playerLevelManager.OnExperienceChange += SetExperienceValue;
        _playerManager.playerLevelManager.OnChooseUpgrade += ShowUpgradePanel;
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
}
