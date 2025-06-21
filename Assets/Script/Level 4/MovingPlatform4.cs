using UnityEngine;

public class MovingPlatform4 : MonoBehaviour
{
    [Header("Posisi Awal dan Tujuan")]
    public Vector3 pointA;  // Titik awal platform
    public Vector3 pointB;  // Titik tujuan platform

    [Header("Kecepatan Gerak")]
    [Tooltip("Kecepatan platform bergerak antara pointA dan pointB (unit per detik)")]
    public float speed = 2f;

    [Header("Delay (opsional)")]
    [Tooltip("Waktu berhenti sementara sebelum kembali (detik)")]
    public float waitTimeAtEachPoint = 0f;

    private bool isMoving = false;
    private Vector3 target;
    private float waitTimer = 0f;

    void Start()
    {
        transform.position = pointA;
        target = pointB;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                isMoving = false;

                // Set timer tunggu sebelum berbalik arah
                waitTimer = waitTimeAtEachPoint;

                // Tukar target
                target = (target == pointA) ? pointB : pointA;
            }
        }
        else if (waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                isMoving = true;
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
