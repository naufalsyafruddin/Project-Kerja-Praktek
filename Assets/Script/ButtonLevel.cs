using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    public int levelIndex;
    public string sceneName;
    public GameObject lockOverlay;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("Button component not found on this GameObject!");
            return;
        }

        int unlockedLevel = PlayerPrefs.GetInt("LevelUnlocked", 2);

        if (levelIndex <= unlockedLevel)
        {
            button.interactable = true;
            if (lockOverlay != null) lockOverlay.SetActive(false);
        }
        else
        {
            button.interactable = false;
            if (lockOverlay != null) lockOverlay.SetActive(true);
        }

        button.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
