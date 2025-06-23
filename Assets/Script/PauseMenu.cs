using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Drag Panel Pause Menu ke sini di Inspector

    private bool isPaused = false;

    void Update()
    {
        // Deteksi tombol ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Jika sedang pause, lanjutkan game
            }
            else
            {
                PauseGame(); // Jika tidak pause, aktifkan pause menu
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Nonaktifkan panel pause
        Time.timeScale = 1f; // Lanjutkan waktu (normal speed)
        isPaused = false;
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame() dipanggil!");
        if (pauseMenuPanel == null)
        {
            Debug.LogError("pauseMenuPanel belum di-assign di Inspector!");
            return;
        }

        pauseMenuPanel.SetActive(true); // Aktifkan panel pause
        Time.timeScale = 0f; // Hentikan waktu (freeze game)
        isPaused = true;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Kembalikan waktu ke normal sebelum berpindah scene
        SceneManager.LoadScene("Lobby"); // Ganti "Lobby" sesuai nama scene Main Menu kamu
    }

    // Fungsi untuk restart level
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Pastikan waktu kembali normal
        Scene currentScene = SceneManager.GetActiveScene(); // Ambil scene saat ini
        SceneManager.LoadScene(currentScene.name); // Load ulang scene yang sedang dimainkan
    }
}
