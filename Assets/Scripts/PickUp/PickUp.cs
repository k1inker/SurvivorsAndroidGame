using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ConstantName.Tags.Player)
        {
            GetComponent<IPickUp>().PickUpAction(collision.GetComponent<PlayerManager>());
            Destroy(gameObject);
        }
    }
}
