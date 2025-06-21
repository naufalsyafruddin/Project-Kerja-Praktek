using UnityEngine;

public class LaserController2 : MonoBehaviour
{
    public GameObject laser;
    public ButtonController2 buttonA;
    public ButtonController2 buttonB;

    private bool laserDisabled = false;

    public void CheckButtons()
    {
        if (laser == null || laserDisabled) return;

        if (buttonA.IsPressed && buttonB.IsPressed)
        {
            laser.SetActive(false);       // Nonaktifkan laser
            laserDisabled = true;         // Tandai sebagai sudah dinonaktifkan permanen
        }
    }
}
