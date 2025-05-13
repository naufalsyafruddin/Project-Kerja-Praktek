using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public LaserController laser; // Laser yang dikontrol
    private bool isHolding = false; // Status apakah tombol sedang ditekan

    void Update()
    {
        if (isHolding)
        {
            laser.DeactivateLaser(); // Matikan laser saat tombol ditekan
        }
        else
        {
            laser.ActivateLaser(); // Aktifkan laser kembali saat tombol dilepas
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Jika pemain menyentuh tombol
        {
            isHolding = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Jika pemain meninggalkan tombol
        {
            isHolding = false;
        }
    }
}