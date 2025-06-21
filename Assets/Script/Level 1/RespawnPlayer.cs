using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public float respawnDelay = 1.0f;
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            StartCoroutine(Respawn());
        }
    }

    // Jadikan public agar bisa dipanggil dari enemy patrol
    public IEnumerator Respawn()
    {
        spriteRenderer.enabled = false;
        rb.velocity = Vector2.zero;
        rb.simulated = false;

        // Disable collider untuk sementara supaya tidak langsung kena musuh saat respawn
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint != null ? respawnPoint.position : initialPosition;
        rb.simulated = true;
        spriteRenderer.enabled = true;

        // Hidupkan collider kembali
        col.enabled = true;

        LaserController[] lasers = FindObjectsOfType<LaserController>();
        foreach (LaserController laser in lasers)
        {
            laser.ResetLaser();
        }
    }
}
