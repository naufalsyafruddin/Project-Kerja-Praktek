using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypointIndex = 0;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

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
        Patrol();
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

        // Flip arah musuh
        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }

        // Ganti ke waypoint berikutnya jika sudah sampai
        if (distance < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
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
}
