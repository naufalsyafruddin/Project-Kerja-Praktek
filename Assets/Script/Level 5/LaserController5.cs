using UnityEngine;

public class LaserController5 : MonoBehaviour
{
    [Header("Laser yang akan dimatikan saat tombol L ditekan")]
    public GameObject[] lasers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (GameObject laser in lasers)
            {
                if (laser != null)
                    laser.SetActive(false);
            }

            Debug.Log("Tombol L ditekan - Laser dimatikan");
        }
    }
}
