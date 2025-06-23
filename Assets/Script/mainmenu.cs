using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Fungsi untuk memulai permainan
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Ganti 1 dengan nama/index scene level select
    }

    // Fungsi untuk keluar dari aplikasi
    public void ExitGame()
    {
        Debug.Log("Keluar dari permainan..."); // Hanya muncul di Editor
        Application.Quit(); // Berfungsi hanya di build
    }

    // Fungsi untuk me-reset progress (untuk playtest)
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Progress telah direset.");

        // Restart scene main menu (opsional, untuk refresh UI)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
