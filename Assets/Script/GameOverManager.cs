using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }
}
