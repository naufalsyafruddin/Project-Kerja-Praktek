using System.Collections;
using UnityEngine;

public class KillGround5 : MonoBehaviour
{
    [Header("Titik respawn untuk masing-masing pemain")]
    public Transform respawnPointPlayer1;
    public Transform respawnPointPlayer2;

    [Header("Referensi objek player")]
    public GameObject player1;
    public GameObject player2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer(other));
        }
    }

    IEnumerator RespawnPlayer(Collider2D player)
    {
        Debug.Log("Respawning: " + player.name);

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();

        if (rb != null) rb.simulated = false;
        if (sr != null) sr.enabled = false;

        yield return new WaitForSeconds(0.5f);

        // Tentukan titik respawn berdasarkan objek
        if (player.gameObject == player1 && respawnPointPlayer1 != null)
        {
            player.transform.position = respawnPointPlayer1.position;
            Debug.Log("Player 1 respawned");
        }
        else if (player.gameObject == player2 && respawnPointPlayer2 != null)
        {
            player.transform.position = respawnPointPlayer2.position;
            Debug.Log("Player 2 respawned");
        }
        else
        {
            Debug.LogWarning("Respawn point atau referensi player belum diatur dengan benar.");
        }

        if (rb != null) rb.simulated = true;
        if (sr != null) sr.enabled = true;

        // Reset laser jika diperlukan
        LaserController[] lasers = FindObjectsOfType<LaserController>();
        foreach (LaserController laser in lasers)
        {
            laser.ResetLaser();
        }
    }
}
