using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;  // Titik awal platform (misal: posisi awal)
    public Vector3 pointB;  // Titik tujuan platform (misal: posisi tujuan)
    public float speed = 2f; // Kecepatan platform
    private bool isMoving = false;  // Status apakah platform sedang bergerak
    private bool isAtPointB = false;  // Menandakan apakah platform sudah mencapai titik B
    private Vector3 target;  // Target posisi yang akan dituju

    void Start()
    {
        target = pointB;  // Platform mulai bergerak ke pointB
        transform.position = pointA;  // Posisi awal platform di titik A
    }

    void Update()
    {
        if (isMoving)
        {
            // Platform bergerak menuju target
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Jika sudah sampai ke target, ubah target ke titik lain
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                if (target == pointB)
                {
                    isAtPointB = true;
                    target = pointA;  // Kembali ke titik A setelah mencapai pointB
                }
                else if (target == pointA)
                {
                    isAtPointB = false;
                    target = pointB;  // Kembali ke titik B setelah mencapai pointA
                }

                isMoving = false; // Hentikan sementara pergerakan
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;  // Mulai pergerakan platform
    }
}
