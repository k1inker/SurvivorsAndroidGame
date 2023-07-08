using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator { get; private set; }
    private CharacterStatsManager _stats;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        _stats = GetComponent<CharacterStatsManager>();
    }
    private void OnEnable()
    {
        _stats.OnTakeDamageCharacter += PlayAnimation;
        _stats.OnDeathCharacter += PlayAnimation;
    }
    private void OnDisable()
    {
        _stats.OnTakeDamageCharacter -= PlayAnimation;
        _stats.OnDeathCharacter -= PlayAnimation;
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
