using UnityEngine;

public class ButtonController1 : MonoBehaviour
{
    public enum ButtonMode { Automatic, KeyPress }

    [Header("Mode tombol:")]
    public ButtonMode mode = ButtonMode.Automatic;

    [Header("Laser yang dikontrol")]
    public GameObject[] lasers;

    private bool isPlayerOnButton = false;
    private bool laserIsPermanentlyOff = false;

    void Update()
    {
        if (mode == ButtonMode.KeyPress && isPlayerOnButton && Input.GetKeyDown(KeyCode.L))
        {
            TurnOffLaserPermanently();
            Debug.Log("Mode KeyPress: Laser dimatikan secara permanen dengan tombol L");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = true;

            if (mode == ButtonMode.Automatic)
            {
                ToggleLaser(false);
                Debug.Log("Mode Automatic: Laser dimatikan saat menyentuh tombol");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = false;

            if (mode == ButtonMode.Automatic)
            {
                ToggleLaser(true);
                Debug.Log("Mode Automatic: Laser dinyalakan kembali setelah keluar");
            }
        }
    }

    private void ToggleLaser(bool state)
    {
        if (!laserIsPermanentlyOff)
        {
            foreach (GameObject laser in lasers)
            {
                if (laser != null)
                    laser.SetActive(state);
            }
        }
    }

    private void TurnOffLaserPermanently()
    {
        foreach (GameObject laser in lasers)
        {
            if (laser != null)
                laser.SetActive(false);
        }

        laserIsPermanentlyOff = true;
    }
}
