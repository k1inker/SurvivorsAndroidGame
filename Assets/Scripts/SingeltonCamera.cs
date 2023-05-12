using UnityEngine;

public class SingeltonCamera : MonoBehaviour
{
    private static Camera _currentCamera;
    public static Camera currentCamera
    {
        get
        {
            if(_currentCamera == null)
            {
                _currentCamera = Camera.main;
            }
            return _currentCamera;
        }
    }
}
