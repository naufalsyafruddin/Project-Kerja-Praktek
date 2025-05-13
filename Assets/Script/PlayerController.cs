using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private Rigidbody2D rb;
    private Animator anime;

    public Transform groundDetector;
    private bool isGrounded;
    public LayerMask whatIsGround;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        // Pastikan player menghadap kanan saat mulai
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
        facingRight = true;
    }

    private void Update()
    {
        DetectGround();     // Deteksi tanah dulu sebelum animasi
        PlayerJump();       // Lompatan diatur setelah ground check
        FlipTrigger();      // Balik arah player
        UpdateAnimation();  // Update parameter animasi
    }

    private void FixedUpdate()
    {
        PlayerMovement();   // Gerakan player menggunakan physics
    }

    void PlayerMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = movement;
    }

    void FlipTrigger()
    {
        if (rb.velocity.x < 0 && facingRight)
        {
            FlipPlayer();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
        }
    }

    void DetectGround()
    {
        if (groundDetector == null) return;

        isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.1f, whatIsGround);

        // Debug: Cek grounding
        Debug.Log("Grounded: " + isGrounded);
    }

    void UpdateAnimation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        anime.SetBool("Run", horizontal != 0);
        anime.SetBool("Jump", !isGrounded);
    }

    // Debug gizmo untuk ground detector
    private void OnDrawGizmosSelected()
    {
        if (groundDetector != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundDetector.position, 0.1f);
        }
    }
}
