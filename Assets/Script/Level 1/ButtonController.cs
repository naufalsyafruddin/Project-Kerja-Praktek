using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private int pressCount = 0; // Bisa untuk lebih dari 1 pemain
    public bool IsPressed => pressCount > 0;

    [SerializeField] private LaserController laserController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressCount++;
            NotifyLaserController();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressCount = Mathf.Max(0, pressCount - 1);
            NotifyLaserController();
        }
    }

    private void NotifyLaserController()
    {
        if (laserController != null)
        {
            laserController.CheckButtons();
        }
        else
        {
            Debug.LogWarning($"LaserController belum di-assign di {gameObject.name}");
        }
    }
}
