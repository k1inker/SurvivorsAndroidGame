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
    protected override void Awake()
    {
        base.Awake();
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        uiManager = GetComponentInChildren<UIManager>();
    }
    private void Update()
    {
        inputHandler.TickInput();
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandelMovment(inputHandler.moveInput.normalized);
    }
}
