using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterLocomotionManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] public float collisionOffset;
    [SerializeField] private ContactFilter2D contactFilter;

    public Rigidbody2D _rb;
    private CapsuleCollider2D _capsuleCollider;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private CharacterManager _character;
    protected virtual void Awake()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
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
    protected bool TryMove(Vector2 direction)
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
            _rb.MovePosition(_rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }
}
