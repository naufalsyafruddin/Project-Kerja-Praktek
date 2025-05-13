using System.Collections;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public Transform spawnPoint; // Titik respawn

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1"))
        {
            StartCoroutine(RespawnPlayer(other));
        }
    }

    IEnumerator RespawnPlayer(Collider2D player)
    {
        // Nonaktifkan sementara kendali pemain
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();

        if (rb != null) rb.simulated = false;
        if (spriteRenderer != null) spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.5f); // Tunggu 0,5 detik sebelum respawn

        // Pindahkan pemain ke titik respawn
        player.transform.position = spawnPoint.position;

        // Aktifkan kembali kendali pemain
        if (rb != null) rb.simulated = true;
        if (spriteRenderer != null) spriteRenderer.enabled = true;

        // Aktifkan kembali semua laser di scene
        LaserController[] lasers = FindObjectsOfType<LaserController>();
        foreach (LaserController laser in lasers)
        {
            laser.ResetLaser();
        }
    }
}
