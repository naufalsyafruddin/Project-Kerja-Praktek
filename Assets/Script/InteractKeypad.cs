using UnityEngine;

public class InteractKeypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadUI;

    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            keypadUI.SetActive(true);
            Time.timeScale = 0f; // Freeze gameplay saat UI dibuka
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = false;
        }
    }
}
