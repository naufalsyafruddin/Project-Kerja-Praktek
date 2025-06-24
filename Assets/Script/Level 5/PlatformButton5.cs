using UnityEngine;

public class PlatformButton5 : MonoBehaviour
{
    public MovingPlatform5 platform;  // Referensi ke script MovingPlatform
    private bool isPlayerNearby = false;  // Status apakah pemain dekat tombol

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            platform.StartMoving();  // Mulai pergerakan platform saat tombol ditekan
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;  // Pemain berada dekat tombol
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;  // Pemain keluar dari trigger tombol
        }
    }
}