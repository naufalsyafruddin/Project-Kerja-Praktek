using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Player sebagai target
    public Vector3 offset; // Offset posisi kamera dari player
    public float smoothSpeed = 0.3f; // Kehalusan pergerakan kamera

    void LateUpdate()
    {
        if (target == null) return; // Jika target tidak ada, hentikan eksekusi

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
