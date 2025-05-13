using UnityEngine;

public class LaserController : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private bool isLaserActive = true; // Laser aktif saat game mulai

    void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ToggleLaser(bool state)
    {
        isLaserActive = state;
        spriteRenderer.enabled = state;
        col.enabled = state;
    }

    public void ActivateLaser() // Hidupkan laser kembali
    {
        ToggleLaser(true);
    }

    public void DeactivateLaser() // Matikan laser
    {
        ToggleLaser(false);
    }

    public void ResetLaser() // Pastikan laser kembali menyala saat reset
    {
        ActivateLaser();
    }
}