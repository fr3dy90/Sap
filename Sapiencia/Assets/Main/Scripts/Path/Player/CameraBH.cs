using UnityEngine;

public class CameraBH : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.12f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desirePosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothPosition;
    }
}
