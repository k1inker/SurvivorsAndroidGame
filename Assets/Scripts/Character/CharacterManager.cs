using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterStatsManager characterStatsManager { get; private set; }
    public CharacterLocomotionManager characterLocomotionManager { get; private set; }
    public CharacterAnimatorManager characterAnimatorManager { get; private set; }
    public SpriteRenderer characterRenderer { get; private set; }
    protected virtual void Awake()
    {
        characterStatsManager = GetComponent<CharacterStatsManager>();
        characterLocomotionManager = GetComponent<CharacterLocomotionManager>();
        characterRenderer = GetComponent<SpriteRenderer>();
        characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
    }
}
