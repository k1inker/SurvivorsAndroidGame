using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;
    private CharacterManager _character;
    protected virtual void Awake()
    {
        _character = GetComponent<CharacterManager>();
    }
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(int countDamage)
    {
        _character.characterAnimatorManager.PlayAnimation(ConstantName.Animation.Damage);
        if (currentHealth - countDamage > 0)
        {
            currentHealth -= countDamage;
        }
        else
        {
            currentHealth = 0;
            HandlerDeath();
        }
    }
    public virtual void HandlerDeath()
    {
        _character.characterAnimatorManager.PlayAnimation(ConstantName.Animation.Death);
    }
}
