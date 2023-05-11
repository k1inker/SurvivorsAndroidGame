using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/FromAboveWeapon")]
public class WeaponFromAbove : Weapon, IWeapon
{
    [Header("SettingsFromAboveWeapon")]
    [SerializeField] private float radiusPotentialDrop;
    private Vector2 destinationPoint;
    public void PathBullet()
    {
        Debug.Log(1);
    }

    public override void SpawnWeapon(PlayerManager player)
    {
        // get top screen point 
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).y;

        // get a random point in the radius around the player's position
        Vector3 randomOffset = Random.insideUnitCircle.normalized * radiusPotentialDrop;
        destinationPoint = player.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
       
        Vector2 spawnPosition = new Vector2(destinationPoint.x, screenTop);
        Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }
}
