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
        if (collision.CompareTag("Obstacle")) // Jika terkena obstacle selain laser
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        spriteRenderer.enabled = false;
        rb.velocity = Vector2.zero;
        rb.simulated = false;
        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint != null ? respawnPoint.position : initialPosition;
        rb.simulated = true;
        spriteRenderer.enabled = true;

        // Hidupkan kembali semua laser yang ada di dalam game
        LaserController[] lasers = FindObjectsOfType<LaserController>();
        foreach (LaserController laser in lasers)
        {
            laser.ResetLaser(); // Memastikan laser kembali menyala
        }
    }
}
