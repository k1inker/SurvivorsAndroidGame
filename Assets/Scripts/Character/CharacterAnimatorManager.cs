using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    public Animator animator { get; private set; }
    private CharacterManager _characterManager;
    protected virtual void Awake()
    {
        _characterManager = GetComponent<CharacterManager>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _characterManager.characterStatsManager.OnTakeDamageCharacter += PlayAnimation;
        _characterManager.characterStatsManager.OnDeathCharacter += PlayAnimation;
    }
    public void SetAnimatorMove(bool isMove)
    {
        animator.SetBool(ConstantName.AnimatorParametrs.IsMoving, isMove);
    }
    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }
}
