using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<Weapon> weapons;
    public Vector2 lookDirection { get; private set; } = Vector2.down;
    private PlayerManager _player;
    private void Awake()
    {
        _player = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        StartAttackAllWeapons();
    }
    private void Update()
    {
        if (_player.inputHandler.moveInput != Vector2.zero)
            lookDirection = _player.inputHandler.moveInput;
    }
    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        StopAllCoroutines();
        StartAttackAllWeapons();
    }
    public void PathBulletConroler()
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon is IWeapon)
            {
                IWeapon iWeapon = (IWeapon)weapon;
                iWeapon.PathBullet();
            }
        }
    }
    private void StartAttackAllWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            StartCoroutine(Attack(weapon));
        }
    }
    private IEnumerator Attack(Weapon currentWeapon)
    {
        while (true)
        {
            currentWeapon.SpawnWeapon(_player);
            yield return new WaitForSeconds(currentWeapon.reloadDelay);
        }
    }
}
