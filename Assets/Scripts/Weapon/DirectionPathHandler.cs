using UnityEngine;

public class DirectionPathHandler : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ConstantName.Tags.Enemy)
        {
            collision.GetComponent<CharacterStatsManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
