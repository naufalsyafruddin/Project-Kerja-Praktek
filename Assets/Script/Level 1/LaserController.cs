using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laser;
    public ButtonController buttonA;
    public ButtonController buttonB;

    private void Update()
    {
        CheckButtons();
    }

    public void CheckButtons()
    {
        if (laser == null) return;

        // Laser mati jika ada tombol yang ditekan
        if (buttonA.IsPressed || buttonB.IsPressed)
        {
            laser.SetActive(false);
        }
        else
        {
            laser.SetActive(true);
        }
    }

    public void ResetLaser()
    {
    laser.SetActive(true); // Atau kondisi default Anda
    }

}
