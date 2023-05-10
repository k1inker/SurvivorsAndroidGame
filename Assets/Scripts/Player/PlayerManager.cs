using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public InputHandler inputHandler { get; private set; }
    public PlayerLocomotion playerLocomotion { get; private set; }
    public PlayerStatsManager playerStatsManager { get; private set; }
    public UIManager uiManager { get; private set; }
    //singelton
    private static PlayerManager _instance;
    public static PlayerManager Instance { 
        get {  
            if(_instance==null) 
                _instance = FindObjectOfType<PlayerManager>();
            return _instance;
        } 
    }

    [Header("PlayerAttackSettings")]
    public List<Weapon> weapons;
    public Vector2 lookDirection { get; private set; } = Vector2.down;
    protected override void Awake()
    {
        base.Awake();
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
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
    }
    private IEnumerator Attack(Weapon currentWeapon)
    {
        while (true)
        {
            currentWeapon.SpawnWeapon(Instance);
            yield return new WaitForSeconds(currentWeapon.reloadDelay);
        }
    }
}
