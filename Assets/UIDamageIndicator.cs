using TMPro;
using UnityEngine;

public class UIDamageIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDamageIndicator;

    private void Awake()
    {
        textDamageIndicator = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        GetComponentInParent<EnemyStatsManager>().onDamageEnemy += SetTextDamageIndicator;
    }
    private void SetTextDamageIndicator(int countDamage)
    {
        textDamageIndicator.text = countDamage.ToString();
    }
}
