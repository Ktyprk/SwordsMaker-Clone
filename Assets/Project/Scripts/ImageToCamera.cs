using UnityEngine;

public class ImageToCamera : MonoBehaviour
{
    public Camera mainCamera;
    void Update()
    {
        if (mainCamera != null)
        {
            Vector3 direction = mainCamera.transform.position - transform.position;
            
            direction.y = 0;
            
            transform.rotation = Quaternion.LookRotation(-direction);
        }
    }
}
