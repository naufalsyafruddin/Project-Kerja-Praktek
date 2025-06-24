using UnityEngine;

public class LaserSwitchButton : MonoBehaviour
{
    public GameObject laserObject;         // Laser yang akan dimatikan
    public float interactionDistance = 3f; // Jarak maksimal interaksi
    public KeyCode interactKey = KeyCode.E;

    private Transform player;
    private bool isPlayerNear = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        isPlayerNear = distance <= interactionDistance;

        if (isPlayerNear)
        {
            // Tampilkan UI [E] to Interact di sini (jika pakai UI)
            if (Input.GetKeyDown(interactKey))
            {
                ToggleLaser();
            }
        }
    }

    void ToggleLaser()
    {
        if (laserObject != null)
        {
            laserObject.SetActive(false);
            Debug.Log("Laser dimatikan!");
        }
    }

    // Optional: tambahkan OnDrawGizmos untuk debug jarak
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
