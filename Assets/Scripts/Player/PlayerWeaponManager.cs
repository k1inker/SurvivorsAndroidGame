using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponData startWeapon;

    public List<WeaponData> weapons;

    private PlayerManager _player;
    public Vector2 lookDirection { get; private set; } = Vector2.down;
    private void Awake()
    {
        _player = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        AddWeapon(startWeapon);
    }
    private void Update()
    {
        if (_player.inputHandler.moveInput != Vector2.zero)
            lookDirection = _player.inputHandler.moveInput.normalized;
    }
    private void FixedUpdate()
    {
        foreach(var weapon in weapons)
        {
            if (weapon is IWeaponPath weaponPath)
            {
                weaponPath.PathBullet();
            }
        }
    }
    public void AddWeapon(WeaponData weaponData)
    {
        weaponData.Initialize();

        weapons.Add(weaponData);

        StartCoroutine(AttackWeapon(weaponData));

        _player.playerLevelManager.UpdateListUpgrades(weaponData.upgradesData);
    }
    public void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponData weaponToUpgrade = weapons.Find(weapon => weapon == upgradeData.weaponData);
        StopCoroutine(AttackWeapon(weaponToUpgrade));
        weaponToUpgrade.AddStatsWeapon(upgradeData.weaponUpgradeStats);
        StartCoroutine(AttackWeapon(weaponToUpgrade));
    }
    private IEnumerator AttackWeapon(WeaponData data)
    {
        while (true)
        {
            for (int i = 0; i < data.weaponStats.countAttack; i++)
            {
                data.Attack(this);
                yield return new WaitForSeconds(.3f);
            }
            yield return new WaitForSeconds(data.weaponStats.reloadDelay);
        }
    }
}
