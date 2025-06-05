using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public LaserController laser; // Referensi ke laser yang akan dikontrol
    private int playersOnButton = 0; // Jumlah player yang sedang menekan tombol

    void Update()
    {
        if (playersOnButton > 0)
        {
            laser.DeactivateLaser(); // Matikan laser kalau ada player di tombol
        }
        else
        {
            laser.ActivateLaser(); // Aktifkan laser kembali kalau tombol kosong
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersOnButton++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersOnButton--;
            // Hindari nilai negatif karena bisa error jika tabrakan tidak konsisten
            playersOnButton = Mathf.Max(playersOnButton, 0);
        }
    }
}
