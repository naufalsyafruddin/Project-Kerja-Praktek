using UnityEngine;

public class ButtonController2 : MonoBehaviour
{
    public LaserController2 laserController;

    private bool isPressed = false;
    public bool IsPressed => isPressed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = true;
            laserController.CheckButtons();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = false;
            laserController.CheckButtons();
        }
    }
}
