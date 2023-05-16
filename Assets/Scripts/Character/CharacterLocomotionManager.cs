using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterLocomotionManager : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    [SerializeField] protected float collisionOffset;
    [SerializeField] protected ContactFilter2D contactFilter;

    protected CapsuleCollider2D _capsuleCollider;
    protected List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    protected CharacterManager _character;

    private Vector2 directionPush;
    private float knockbackForce;
    private bool hasUnchangingPath = false;
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
            // logic pushingBack
            float speed = moveSpeed;

            if (hasUnchangingPath)
            {
                speed = knockbackForce;
                moveVector = directionPush;
            }

            bool isMove = TryMove(moveVector,speed);
            if (!isMove)
            {
                isMove = TryMove(new Vector2(moveVector.x, 0), speed);
            }
            if (!isMove)
            {
                isMove = TryMove(new Vector2(0, moveVector.y), speed);
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
    protected virtual bool TryMove(Vector2 direction, float speed)
    {
        if (direction == Vector2.zero)
        {
            return false;
        }
        int count = _capsuleCollider.Cast(direction,
                        contactFilter,
                        castCollisions,
                        moveSpeed * Time.deltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void KnockBack(Vector2 direction, float knockbackForce)
    {
        hasUnchangingPath = true;
        directionPush = direction;
        this.knockbackForce = knockbackForce;
        StartCoroutine(KnockBackShock());
    }
    private IEnumerator KnockBackShock()
    {
        yield return new WaitForSeconds(.15f);
        hasUnchangingPath = false;
    }
}
