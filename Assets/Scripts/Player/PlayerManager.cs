using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public InputHandler inputHandler { get; private set; }
    public PlayerLocomotion playerLocomotion { get; private set; }
    public PlayerStatsManager playerStatsManager { get; private set; }
    public PlayerLevelManager playerLevelManager { get; private set; }
    public PlayerWeaponManager playerWeaponManager { get; private set; }
    public ManagerUI uiManager { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerLevelManager = GetComponent<PlayerLevelManager>();
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
        uiManager = GetComponentInChildren<ManagerUI>();
    }
    private void Update()
    {
        inputHandler.TickInput();
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandelMovment(inputHandler.moveInput.normalized);
        playerWeaponManager.PathBulletConroler();
    }
}
