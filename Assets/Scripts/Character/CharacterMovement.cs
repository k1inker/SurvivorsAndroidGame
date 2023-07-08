using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private bool isStunned = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        isStunned = false;
    }
    public void HandelMovment(Vector2 moveVector)
    {
        if (isStunned)
            return;

        if (moveVector == Vector2.zero)
        {
            _rb.velocity = Vector2.zero;
            //_character.characterAnimatorManager.SetAnimatorMove(false);
            return;
        }
        _rb.velocity = moveVector * moveSpeed * Time.deltaTime;

        if (moveVector.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveVector.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
    public void KnockBack(Vector2 direction, float knockbackForce)
    {
        _rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(StunTime(.15f));
    }
    private IEnumerator StunTime(float time)
    {
        isStunned = true;
        yield return new WaitForSeconds(time);
        isStunned = false;
    }
}
