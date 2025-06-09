using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypointIndex = 0;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("Crush Detection")]
    public LayerMask platformLayer;
    public float checkHeight = 0.1f;
    public Vector2 checkSize = new Vector2(0.5f, 0.1f);
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (waypoints.Length == 0)
        {
            Debug.LogWarning("Tidak ada waypoint!");
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;

        Patrol();
        CheckIfCrushed();
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPosition);

        float distance = Vector2.Distance(rb.position, target.position);
        animator.SetBool("isWalking", distance > 0.1f);

        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }

        if (distance < 5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void CheckIfCrushed()
    {
        Vector2 checkPosition = (Vector2)transform.position + Vector2.up * (GetComponent<Collider2D>().bounds.extents.y + checkHeight);
        Collider2D hit = Physics2D.OverlapBox(checkPosition, checkSize, 0f, platformLayer);
        if (hit != null)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("isWalking", false);
        Destroy(gameObject, 0.1f);
    }

    // **Tambah fungsi trigger untuk bunuh player**
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                StartCoroutine(player.Respawn());
            }
        }
    }

    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] != null)
            {
                Gizmos.DrawSphere(waypoints[i].position, 0.1f);
                int nextIndex = (i + 1) % waypoints.Length;
                if (waypoints[nextIndex] != null)
                {
                    Gizmos.DrawLine(waypoints[i].position, waypoints[nextIndex].position);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (GetComponent<Collider2D>() == null) return;

        Gizmos.color = Color.yellow;
        Vector2 checkPosition = (Vector2)transform.position + Vector2.up * (GetComponent<Collider2D>().bounds.extents.y + checkHeight);
        Gizmos.DrawWireCube(checkPosition, checkSize);
    }
}
