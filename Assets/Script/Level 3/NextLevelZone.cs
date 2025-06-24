using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelZone : MonoBehaviour
{
    public string nextSceneName = "Level2";
    public int nextLevelIndex = 1;
    public int requiredPlayers = 1;

    private int playersInTrigger = 0;
    private bool isLoading = false;
    public bool isZoneActive = false; // ← Tambahan penting

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isZoneActive) return; // Jangan lanjut jika zona belum aktif

        if (other.CompareTag("Player"))
        {
            playersInTrigger++;
            CheckIfReady();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrigger = Mathf.Max(0, playersInTrigger - 1);
        }
    }

    void CheckIfReady()
    {
        if (!isLoading && playersInTrigger >= requiredPlayers)
        {
            isLoading = true;

            int currentUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 0);
            if (nextLevelIndex > currentUnlocked)
            {
                PlayerPrefs.SetInt("LevelUnlocked", nextLevelIndex);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene(nextSceneName);
        }
    }

    // Dipanggil dari script puzzle
    public void EnableNextZone()
    {
        isZoneActive = true;
        Debug.Log("Zona next level telah diaktifkan.");
    }
}
