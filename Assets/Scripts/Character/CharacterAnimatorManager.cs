using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    public Animator animator { get; private set; }
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void SetAnimatorMove(bool isMove)
    {
        animator.SetBool(ConstantName.AnimatorParametrs.IsMoving, isMove);
    }
}
