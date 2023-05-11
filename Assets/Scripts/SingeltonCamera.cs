using UnityEngine;

public class SingeltonCamera : MonoBehaviour
{
    public static Camera currentCamera
    {
        get
        {
            if(currentCamera == null)
            {
                currentCamera = Camera.main;
            }
            return currentCamera;
        }
        private set { }
    }
}
