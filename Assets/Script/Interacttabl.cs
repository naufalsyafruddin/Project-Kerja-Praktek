using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2f, 0);
    public float showDistance = 3f;

    private Transform player;
    private Canvas canvas;
    private TextMeshProUGUI textUI;

    void Start()
    {
        // Cari player berdasarkan tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("Player with tag 'Player' not found.");
            return;
        }
        player = playerObj.transform;

        // Buat Canvas baru
        GameObject canvasGO = new GameObject("E_UI_Canvas");
        canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        // Tambahkan CanvasScaler agar teks terlihat proporsional
        CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
        scaler.dynamicPixelsPerUnit = 10;

        // Buat teks "[E] To Interact"
       // Buat teks "[E] To Interact"
    GameObject textGO = new GameObject("E_Text");
textGO.transform.SetParent(canvasGO.transform, false);
textUI = textGO.AddComponent<TextMeshProUGUI>();
textUI.text = "[E] To Interact";
textUI.fontSize = 1;
textUI.alignment = TextAlignmentOptions.Center;

RectTransform textRect = textUI.GetComponent<RectTransform>();
textRect.sizeDelta = new Vector2(6, 2); // <- INI yang diperbesar agar teks tidak turun ke bawah


        canvasGO.SetActive(false); // Sembunyikan awalnya
    }

    void Update()
    {
        if (player == null || canvas == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        canvas.transform.position = transform.position + offset;

        // Menghadap kamera
        Vector3 dir = canvas.transform.position - Camera.main.transform.position;
        canvas.transform.rotation = Quaternion.LookRotation(dir);

        // Tampilkan jika dekat
        canvas.gameObject.SetActive(distance <= showDistance);
    }

    void OnDestroy()
    {
        if (canvas != null)
        {
            Destroy(canvas.gameObject);
        }
    }
}
