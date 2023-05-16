using UnityEngine;

public class LevelParticle : MonoBehaviour
{
    [SerializeField] private ushort value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ConstantName.Tags.Player)
        {
            collision.GetComponent<PlayerLevelManager>().IncreaseExperienceValue(value);
            Destroy(gameObject);
        }
    }
}
