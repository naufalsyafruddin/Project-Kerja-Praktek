using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    public GameObject popupPrefab;
    private GameObject currentPopup;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowPopup(Transform target)
    {
        if (popupPrefab == null) return;

        if (currentPopup == null)
        {
            currentPopup = Instantiate(popupPrefab);
        }

        currentPopup.SetActive(true);
        currentPopup.transform.position = target.position + Vector3.up * 1.5f;
    }

    public void HidePopup()
    {
        if (currentPopup != null)
            currentPopup.SetActive(false);
    }
}
