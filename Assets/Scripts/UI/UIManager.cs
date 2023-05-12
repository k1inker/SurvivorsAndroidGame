using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider _slider { get; private set; }
    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
    }
    public void SetMaxHealthValue(float maxHealth)
    {
        _slider.maxValue = maxHealth;
    }
    public void SetHealthValue(float currentHealth)
    {
        _slider.value = currentHealth;
    }

}
