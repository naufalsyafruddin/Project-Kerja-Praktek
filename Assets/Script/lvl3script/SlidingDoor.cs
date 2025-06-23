using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(0, 3, 0);
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private int playersInTrigger = 0;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    void Update()
    {
        Vector3 target = (playersInTrigger > 0) ? openPosition : closedPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, openSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrigger++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrigger = Mathf.Max(0, playersInTrigger - 1);
        }
    }
}
