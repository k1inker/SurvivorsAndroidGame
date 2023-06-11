using DG.Tweening;
using NTC.Global.Pool;
using System.Collections;
using TMPro;
using UnityEngine;

public class DamageIndicatorUI : MonoBehaviour
{
    [SerializeField] private GameObject textDamageIndicator;
    public void SpawnIndicator(Vector2 pointSpawn, int countDamage)
    {
        GameObject indicator = NightPool.Spawn(textDamageIndicator, null, pointSpawn, Quaternion.identity);
        indicator.transform.SetParent(transform);

        var textPopUp = indicator.GetComponent<TextMeshProUGUI>();

        textPopUp.text = countDamage.ToString();

        DOTween.Sequence()
            .Append(textPopUp.DOFade(1f, 0.5f))
            .Append(textPopUp.DOFade(0f, 0.5f))
            .AppendCallback(() => NightPool.Despawn(indicator.gameObject));
    }
}
