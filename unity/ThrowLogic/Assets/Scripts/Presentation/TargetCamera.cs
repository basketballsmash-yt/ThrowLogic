using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    public Transform target;      
    public float distance = 10f;   
    public float zoomSpeed = 2f;  
    public float rotateSpeed = 5f; 

    private float yaw = 0f;       
    private float pitch = 20f;    
    private float minDistance = 2f;
    private float maxDistance = 10f;
    private float minPitch = -20f;
    private float maxPitch = 80f;

    void Update()
    {
        if (target == null) return;

        
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * rotateSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotateSpeed;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        transform.position = target.position + rot * dir;
        transform.LookAt(target.position);
    }
}
