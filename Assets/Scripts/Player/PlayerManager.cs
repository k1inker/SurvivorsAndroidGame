using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public InputHandler inputHandler { get; private set; }
    public PlayerLocomotion playerLocomotion { get; private set; }
    public PlayerStatsManager playerStatsManager { get; private set; }
    public PlayerLevelManager playerLevelManager { get; private set; }
    public UIManager uiManager { get; private set; }

    [Header("PlayerAttackSettings")]
    public List<Weapon> weapons;
    public Vector2 lookDirection { get; private set; } = Vector2.down;
    protected override void Awake()
    {
        base.Awake();
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerLevelManager = GetComponent<PlayerLevelManager>();
        uiManager = GetComponentInChildren<UIManager>();
    }
    private void Start()
    {
        foreach (Weapon weapon in weapons)
        {
            StartCoroutine(Attack(weapon));
        }
    }
    private void Update()
    {
        inputHandler.TickInput();

        if(inputHandler.moveInput != Vector2.zero)
           lookDirection = inputHandler.moveInput;
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandelMovment(inputHandler.moveInput.normalized);
        PathBulletConroler();
    }
    private void PathBulletConroler()
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
    private IEnumerator Attack(Weapon currentWeapon)
    {
        while (true)
        {
            currentWeapon.SpawnWeapon(this);
            yield return new WaitForSeconds(currentWeapon.reloadDelay);
        }
    }
}
