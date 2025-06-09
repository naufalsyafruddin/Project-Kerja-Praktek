using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject panelCODE;     // UI Panel yang akan muncul saat interact
    public GameObject interactText;  // UI Text "Press E to Interact"

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            panelCODE.SetActive(true);
            interactText.SetActive(false);  // sembunyikan teks saat panel muncul
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            interactText.SetActive(true); // tampilkan teks saat player dekat
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            interactText.SetActive(false); // sembunyikan teks saat player jauh
        }
    }
}
