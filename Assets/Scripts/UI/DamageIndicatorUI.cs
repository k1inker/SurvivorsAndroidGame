using System.Collections;
using TMPro;
using UnityEngine;

public class DamageIndicatorUI : MonoBehaviour
{
    [SerializeField] private GameObject textDamageIndicator;
    public void SpawnIndicator(Vector2 pointSpawn, int countDamage)
    {
        GameObject indicator = Instantiate(textDamageIndicator, pointSpawn, Quaternion.identity);
        indicator.transform.SetParent(transform);
        indicator.GetComponent<TextMeshProUGUI>().text = countDamage.ToString();
        StartCoroutine(DestroyIndicator(indicator));
    }
    public IEnumerator DestroyIndicator(GameObject indicator)
    {
        yield return new WaitForSeconds(1f);
        Destroy(indicator.gameObject);
    }
}
