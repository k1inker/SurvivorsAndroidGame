using UnityEngine;
using Zenject;

public class FollowWorldUI : MonoBehaviour
{
    [Inject] private Camera _camera;
    [Inject] private PlayerManager _player;

    [SerializeField] private Vector2 offset;
    private void LateUpdate()
    {
        Vector2 possition = _camera.WorldToScreenPoint((Vector2)_player.transform.position + offset);

        if ((Vector2)transform.position != possition)
            transform.position = possition;
    }
}
