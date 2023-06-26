using NTC.Global.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterLocomotionManager : MonoBehaviour, IPoolItem
{
    public float moveSpeed;
    public Rigidbody2D rb;

    protected CapsuleCollider2D _capsuleCollider;
    protected List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    protected CharacterManager _character;

    [SerializeField] private bool isStunned = false;
    protected virtual void Awake()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        _character = GetComponent<CharacterManager>();
    }
    public virtual void HandelMovment(Vector2 moveVector)
    {
        if (isStunned)
            return;

        if (moveVector == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
            //_character.characterAnimatorManager.SetAnimatorMove(false);
            return;
        }
        rb.velocity = moveVector * moveSpeed * Time.deltaTime;

        if (moveVector.x < 0)
        {
            _character.characterRenderer.flipX = true;
        }
        else if (moveVector.x > 0)
        {
            _character.characterRenderer.flipX = false;
        }
    }
    public virtual void KnockBack(Vector2 direction, float knockbackForce)
    {
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(StunTime(.15f));
    }
    private IEnumerator StunTime(float time)
    {
        isStunned = true;
        yield return new WaitForSeconds(time);
        isStunned = false;
    }
    public void OnSpawn()
    {
        isStunned = false;
    }
    public void OnDespawn()
    {
        
    }
}
