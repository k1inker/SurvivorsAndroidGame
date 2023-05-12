using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterLocomotionManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] public float collisionOffset;
    [SerializeField] protected ContactFilter2D contactFilter;

    public Rigidbody2D rb;
    protected CapsuleCollider2D _capsuleCollider;
    protected List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    protected CharacterManager _character;
    protected virtual void Awake()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        _character = GetComponent<CharacterManager>();
    }
    public virtual void HandelMovment(Vector2 moveVector)
    {
        if (moveVector == Vector2.zero)
        {
            //_character.characterAnimatorManager.SetAnimatorMove(false);
            return;
        }
        else
        {
            bool isMove = TryMove(moveVector);
            if (!isMove)
            {
                isMove = TryMove(new Vector2(moveVector.x, 0));
            }
            if (!isMove)
            {
                isMove = TryMove(new Vector2(0, moveVector.y));
            }
            //_character.characterAnimatorManager.SetAnimatorMove(isMove);
        }

        if (moveVector.x < 0)
        {
            _character.characterRenderer.flipX = true;
        }
        else if (moveVector.x > 0)
        {
            _character.characterRenderer.flipX = false;
        }
    }
    // locomotion for kinematics object
    private bool TryMove(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return false;
        }
        int count = _capsuleCollider.Cast(direction,
                        contactFilter,
                        castCollisions,
                        moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void KnockBack(Vector2 direction, float knockbackForce)
    {
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        //rb.AddRelativeForce(direction * knockbackForce, ForceMode2D.Impulse);
        //rb.MovePosition(rb.position + direction * knockbackForce * Time.fixedDeltaTime);
    }
}
