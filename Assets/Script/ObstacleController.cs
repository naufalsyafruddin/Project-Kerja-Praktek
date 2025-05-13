using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HideObstacle()
    {
        spriteRenderer.enabled = false;
        col.enabled = false;
    }

    public void ShowObstacle()
    {
        spriteRenderer.enabled = true;
        col.enabled = true;
    }
}
